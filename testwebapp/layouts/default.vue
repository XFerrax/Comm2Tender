<template>
  <div>
    <AppHeader />
    <v-main>
      <slot />
    </v-main>
    <AppFooter />
  </div>
</template>

<script lang="ts" setup>
  import AppHeader from '~/components/basecomponents/AppHeader.vue'
  import AppFooter from '~/components/basecomponents/AppFooter.vue'
</script>