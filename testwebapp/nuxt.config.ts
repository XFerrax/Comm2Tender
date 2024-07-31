import vuetify, { transformAssetUrls } from 'vite-plugin-vuetify'
export default defineNuxtConfig({
 ssr: false,
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
 plugins: [
  '~/plugins/pinia.ts'
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

 devtools: {
  enabled: true,
 },
})
