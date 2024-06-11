<template>
  <v-app id="inspire">
    <v-app-bar>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>

      <v-app-bar-title>DreamTeams</v-app-bar-title>
    </v-app-bar>

    <v-navigation-drawer
      v-model="drawer"
      temporary
    >
      <!--  -->
    </v-navigation-drawer>

    <v-main class="bg-grey-lighten-2">
      <v-container fluid>
        <AddBaseWorkButton @click="runForm = true"/>
        <v-row>
        <BaseWorkLayout :inValue="items" />
        
        <v-spacer />
      </v-row>
      </v-container>
      <v-dialog v-model="runForm">
        <AddForm @close-form="runForm = e" />
      </v-dialog>
    </v-main>
  </v-app>
</template>

<script setup>
  import { ref } from 'vue'
  import BaseWorkLayout from '~/Components/BaseWorkLayout.vue'
  import AddBaseWorkButton from '~/Components/AddBaseWorkButton.vue'
  import AddForm from '~/Components/Form.vue'

  const drawer = ref(null)
</script>

<script>
  export default {
    data: () => (
      {
        drawer: null, 
        items:[],
        runForm: false,
        maxHist:0,
        minHist:0,
      }),
      created: () => {

      },
      methods:{
      closeForm()
      {
        this.runForm = !this.runForm

      }
    }
  }
</script>