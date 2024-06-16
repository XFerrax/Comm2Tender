import { defineNuxtPlugin } from '#app'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import '@mdi/font/css/materialdesignicons.css'

import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import { md3 } from 'vuetify/blueprints'

export default defineNuxtPlugin((app) => {
  const vuetify = createVuetify({
    components,
    directives,
    blueprint: md3,
    theme: {
      defaultTheme: 'light',
      themes: {
        light: {
          colors: {
            primary: '#6200ee',
            secondary: '#03dac6',
            background: '#ffffff',
            surface: '#ffffff',
            error: '#b00020',
            onPrimary: '#ffffff',
            onSecondary: '#000000',
            onBackground: '#000000',
            onSurface: '#000000',
            onError: '#ffffff',
          },
        },
      },
    },
  })
  app.vueApp.use(vuetify)
})