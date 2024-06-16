<template>
  <v-app>
    <NuxtLayout :name="authRole">    
        <NuxtPage />
    </NuxtLayout>
  </v-app>
</template>

<script setup lang="ts">
  import type { LayoutKey } from '#build/types/layouts';
  import { useAuthStore } from '~/store/auth.store'

  const authStore = useAuthStore()
  const authRole = computed(() => {
    if (authStore.roleType!='')
    {
      return (authStore.roleType as LayoutKey)
    } 
    return 'default' as LayoutKey
  })
</script>