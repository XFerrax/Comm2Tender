<template>
    <VLayout>
        <VAppBar absolute :elevation="2" rounded title="TenderSelections">
            <template v-slot:prepend>
                <VAppBarNavIcon v-if="myPath != 'login'" @click="rail = !rail" />
            </template>
            <template v-slot:append>
                <VBtn icon="mdi-logout" v-if="myPath != 'login'" @click="logout"/>
            </template>
        </VAppBar>
        <VNavigationDrawer v-model="drawer" permanent v-if="myPath != 'login'" :rail="rail" :width="300">
            <VList>
                <template v-for="item in menu" :key="item.name">
                    <VListItem :to="item.path" link :prepend-icon="item.icon" :title="item.name" />
                </template>
            </VList>
        </VNavigationDrawer>
        <VMain>
            <slot name="mainApp" ></slot>
        </VMain>
    </VLayout>
</template>

<script lang="ts" setup>
import { useAuthStore } from '~/store/auth.store';
import { menuStore } from '~/store/menu.store';
const drawer = true
const rail = ref(false)
const route = useRoute()
const myPath = ref(route.name)
const useMenuStore = menuStore()
const menu = ref(useMenuStore.menuItemsStore)

watchEffect(() => {
    myPath.value = route.name
    menu.value = useMenuStore.menuItemsStore
})

const logout = () => {
    useAuthStore().logout()
}

</script>