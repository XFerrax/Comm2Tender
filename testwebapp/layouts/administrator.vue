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
          name: 'Пользователи',
          path: '/users',
          icon: 'mdi-account-group'
          //icon: 'mdi-account-multiple',
        },
        {
          name: 'Контрагенты',
          path: '/agents',
          icon: 'mdi-briefcase-account',
        },
        {
          name: 'Заявки',
          path: '/proposals',
          icon: 'mdi-invoice-multiple',
        },
        {
          name: 'Процентные ставки',
          path: '/percents',
          icon: 'mdi-bank-plus',
        },
        {
          name: 'Таможенные пошлины',
          path: '/customsfee',
          icon: 'mdi-train-car-box-full',
        },
      ])
</script>