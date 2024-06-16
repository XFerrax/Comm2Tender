<template>
    <div>
        <v-app-bar :elevation="2" rounded title="TenderSelections">
            <template v-slot:prepend>
                <v-app-bar-nav-icon @click="rail = !rail" />
            </template>
        </v-app-bar>

        <v-navigation-drawer v-model="drawer" v-if="menuItems !== undefined" :rail="rail" @click.stop="rail = !rail" :width="300">
            <v-list>
                <template v-for="item in menuItems" :key="item.name">
                    <v-list-item :to="item.path" link :prepend-icon="item.icon" :title="item.name" />
                </template>
            </v-list>
        </v-navigation-drawer>
    </div>
</template>

<script lang="ts" setup>
// import { ref } from 'vue'

const props = defineProps<{
    menuItems?: { name: string, path: string, icon: string }[]
}>()

const drawer = ref(true)
const rail = ref(false)
</script>
      