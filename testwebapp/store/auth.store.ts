import { defineStore } from 'pinia';
import { fetchData } from '~/plugins/api';
import { menuStore } from './menu.store';
import helpers, { HttpQueryType } from '~/utils/helpers';

const $helpers = helpers();

export const useAuthStore = defineStore({
  id: 'auth',
  state: () => ({ }),
  getters: {
    accessToken: (): string | null => getCookie('accessToken') as string | null,
    refreshToken: (): string | null => getCookie('refreshToken') as string | null,
  },
  actions: {
    setTokens(tokens: { accessToken: string | null, refreshToken: string | null }) {
      if (tokens.accessToken) {
		setCookie('accessToken', tokens.accessToken)
      } else {
		deleteCookie('accessToken');
      }

      if (tokens.refreshToken) {
		setCookie('refreshToken', tokens.refreshToken, 14400)
      } else {
        deleteCookie('refreshToken');
      }
    },
    login(email: string, password: string) {
      fetchData('auth/login',
          {
            method: 'post', 
            headers: { 'Content-Type': 'application/json' }, 
            body: JSON.stringify({ login: email, password: password }) 
          })
        .then(response => {
          const data = response;
          this.setTokens({
            accessToken: data.accessToken,
            refreshToken: data.refreshToken 
          })
          fetchData('auth/getUserView', $helpers.BuildQuery(HttpQueryType.get))
            .then(inResponse => {
              const myMenuStore = menuStore();
			        myMenuStore.removeMenuItem()
              myMenuStore.setMenuItems(inResponse.menuItems);
              useRouter().push(inResponse.menuItems[0].path);
            })
        })
        .catch(() => {
          this.logout()
        });
    },
    logout() {
      fetchData('auth/logout', $helpers.BuildQuery(HttpQueryType.get))
        .catch()
        .finally(()=>{
          const myMenuStore = menuStore();
          myMenuStore.removeMenuItem()
          this.setTokens({ accessToken: null, refreshToken: null })
          useRouter().push('/login');
        })
    },
  },
});

function setCookie(name: string, val: string, seconds?: number) {
    const date = new Date();
    const value = val;
	if(seconds) {
		date.setTime(date.getTime() + seconds * 1000);
	}
	else {
    	date.setTime(date.getTime() + (60 * 60 * 1000));
	}

    document.cookie = name + "=" + value + "; expires=" + date.toUTCString() + "; path=/";
}

function getCookie(name: string) {
    const value = "; " + document.cookie;
    const parts = value.split("; " + name + "=");
    
    if (parts.length == 2) {
        return parts.pop()?.split(";").shift();
    }
}

function deleteCookie(name: string) {
    const date = new Date();
    date.setTime(date.getTime() + (-1 * 24 * 60 * 60 * 1000));
    document.cookie = name + "=; expires=" + date.toUTCString() + "; path=/";
}