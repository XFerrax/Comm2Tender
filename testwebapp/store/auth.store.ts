import { HttpQueryType, BuildQuery } from "~/utils/helpers"
import { defineStore } from 'pinia'
import { fetchData } from '~/plugins/api'
import jwtDecode from 'jwt-decode';

interface IUser {
	email: string
	status: boolean
	accessToken: string
	refreshToken: string
	roleType: string
  }

interface IAuthStore {
	user: IUser
}

interface JwtTokenPayload {
	[key: string]: any;
  }

const defaultValue: IAuthStore = {
	user: {
	  email: '',
	  status: false,
	  accessToken: '',
	  refreshToken: '',
	  roleType: '',
	},
  }

  export const useAuthStore = defineStore({
	id: 'auth', // Идентификатор хранилища
	state: (): IAuthStore => defaultValue, // Инициализация состояния
	getters: {
	  accessToken: (state): string => state.user.accessToken,
	  refreshToken: (state): string => state.user.refreshToken,
	  roleType: (state): string => state.user.roleType,
	},
	actions: {
	  async login(email: string, password: string) {
		const response = await fetchData('auth/login', BuildQuery(HttpQueryType.post, { login: email, password: password }))
		const data = await (response as Response).json()
		// Обновление состояния на основе полученных данных
		this.user.accessToken = data.accessToken
		this.user.refreshToken = data.refreshToken
		const jwtToken = jwtDecode<JwtTokenPayload>(data.accessToken)
		const roleKey = Object.keys(jwtToken).find(str => str.includes('role'))
		this.user.roleType = roleKey ? jwtToken[roleKey] : undefined
		this.user.email = email
		this.user.status = true
		const route = useRouter();
		route.push('/')
	  },
	  async logout() {
		await fetch('auth/logout', BuildQuery(HttpQueryType.get))
		// Сброс состояния при выходе
		this.user = { ...defaultValue.user }
	  },
	},
  })