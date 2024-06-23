<template>
  <div>
    <AppHeader :menuItems="myMenuItems">
      <VMain>
        <slot />
      </VMain>
    </AppHeader>
    <AppFooter />
  </div>
</template>

<script lang="ts" setup>
  import AppHeader from '~/components/basecomponents/AppHeader.vue'
  import AppFooter from '~/components/basecomponents/AppFooter.vue'
  import { menuStore } from '~/store/menu.store';


  const myMenuStore = menuStore()
  const myMenuItems = computed(() => myMenuStore.menuItemsStore)
</script>