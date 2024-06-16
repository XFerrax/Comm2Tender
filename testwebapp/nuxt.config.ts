// https://nuxt.com/docs/api/configuration/nuxt-config
import { PiniaVuePlugin } from 'pinia'
import vuetify, { transformAssetUrls } from 'vite-plugin-vuetify'
export default defineNuxtConfig({
  //ssr: false,
  runtimeConfig: {
    public: {
      apiBaseUrl: "http://localhost:5037/api",
    }},
  //...
  build: {
    transpile: ['vuetify'],
  },
  modules: [
    (_options, nuxt) => {
      nuxt.hooks.hook('vite:extendConfig', (config) => {
        // @ts-expect-error
        config.plugins.push(vuetify({ autoImport: true }))
      })
    },
    //...
    '@pinia/nuxt',
  ],
  vite: {
    vue: {
      template: {
        transformAssetUrls,
      },
    },
  },
  pinia: {
		storesDirs: ['./store/**'],
	},
})