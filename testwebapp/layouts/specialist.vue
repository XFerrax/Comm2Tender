<template>
  <div>
    <AppHeader :menuItems="menuItems" />
    <v-main>
      <slot />
    </v-main>
    <AppFooter />
  </div>
</template>

<script lang="ts" setup>
  import { ref } from 'vue'
  import AppHeader from '~/components/basecomponents/AppHeader.vue'
  import AppFooter from '~/components/basecomponents/AppFooter.vue'

  const menuItems = ref([
        {
          name: 'Контрагенты',
          path: '/agents',
          icon: 'mdi-briefcase-account',
        },
        {
          name: 'Заявки',
          path: '/proposals',
          icon: 'mdi-checkbox-multiple-blank-outline',
        },
      ])
</script>