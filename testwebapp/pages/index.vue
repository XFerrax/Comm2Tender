<template>
  <v-app>
    <v-main class="bg-grey-lighten-2">
      <!-- <v-container fluid>
        <AddBaseWorkButton @click="runForm = true"/>
        <v-row>
        <BaseWorkLayout :inValue="items" />
        
        <v-spacer />
      </v-row>
      </v-container>
      <v-dialog v-model="runForm">
        <AddForm @close-form="runForm = e" />
      </v-dialog> -->
    </v-main>
  </v-app>
</template>

<script setup>
  import { ref } from 'vue'
  // import BaseWorkLayout from '~/components/BaseWorkLayout.vue'
  // import AddBaseWorkButton from '~/components/AddBaseWorkButton.vue'
  // import AddForm from '~/components/Form.vue'

</script>

<script>
  export default {
    // data: () => (
    //   {
    //     drawer: null, 
    //     items:[],
    //     runForm: false,
    //     maxHist:0,
    //     minHist:0,
    //   }),
    //   created: () => {

    //   },
    //   methods:{
    //   closeForm()
    //   {
    //     this.runForm = !this.runForm

    //   }
    // }
  }
</script>