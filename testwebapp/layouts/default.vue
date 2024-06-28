<template>
  <div>
    <AppHeader>
      <template #mainApp>
        <slot />
      </template>
    </AppHeader>
    <AppFooter />
  </div>
</template>

<script lang="ts" setup>
  import AppHeader from '~/components/basecomponents/AppHeader.vue'
  import AppFooter from '~/components/basecomponents/AppFooter.vue'
</script>