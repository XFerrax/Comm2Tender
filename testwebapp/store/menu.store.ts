import { defineStore } from 'pinia'

interface IMenuItem {
  name: string,
  path: string,
  icon: string,
  readonly: boolean,
}

const defaultValue: Array<IMenuItem> = [ ]

export const menuStore = defineStore({
  id: 'menuStore',
  state: () => ({
    //menuItemsStore: defaultValue,
  }),
  getters: {
    menuItemsStore: () => {
      const data = localStorage.getItem('menu')
      if(data) {
        return JSON.parse(data)
      }
      return [];
    }
  },
  persist: true,
  actions: {
    setMenuItems(items: IMenuItem[]) {
      localStorage.setItem('menu', JSON.stringify(items))
    },
    removeMenuItem() {
      localStorage.removeItem('menu')
    },
  }
})
