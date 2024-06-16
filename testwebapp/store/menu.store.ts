import { defineStore } from 'pinia'

interface IMenuItem {
  name: string,
  path: string,
  icon: string,
  readonly: boolean,
}

const defaultValue: Array<IMenuItem> = [ ]

export const useMyMenuStore = defineStore({
  id: 'myMenuStore',
  state: () => ({ }),
  actions: {}
})
