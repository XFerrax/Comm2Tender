<template>
    <VLayout>
        <VAppBar absolute :elevation="2" rounded title="TenderSelections">
            <template v-slot:prepend>
                <VAppBarNavIcon @click="rail = !rail" />
            </template>
        </VAppBar>
        <VNavigationDrawer v-if="menuItems.length != 0" :rail="rail" :width="300">
            <VList>
                <template v-for="item in menuItems" :key="item.name">
                    <VListItem :to="item.path" link :prepend-icon="item.icon" :title="item.name" />
                </template>
            </VList>
        </VNavigationDrawer>
        <slot />
    </VLayout>
</template>

<script lang="ts" setup>
const props = defineProps<{
    menuItems: { name: string, path: string, icon: string }[]
}>()

const drawer = ref(true)
const rail = ref(false)
</script>