<template>
  <VForm ref="form" fast-fail>
    <VCard class="elevation-10">
      <VToolbar color="primary" class="flex-grow-0">
        <VToolbarTitle>{{ 'Добавить пользователя' }}</VToolbarTitle>
        <VSpacer />
        <VToolbarItems>
          <VBtn density="comfortable" variant="tonal" @click="close" icon="mdi-close" />
        </VToolbarItems>
      </VToolbar>
      <VCardText>
        <slot name="fields" />
      </VCardText>
      <VCardActions class="pa-4">
        <VLayout wrap>
          <!-- <v-flex v-if="completed > -1" xs12>
            <VProgressLinear class="mb-4" :value="completed" :buffer-value="completed" :indeterminate="indeterminate" stream rounded />
          </v-flex> -->
          <VLayout justify-center>
            <VSpacer />
            <!-- <VBtn :disabled="disableSaveButton || !formValid || disableActions" color="primary" variant="tonal" @click="save" text="Сохранить" /> -->
            <VBtn color="primary" variant="tonal" @click="save" text="Сохранить" />
            <VBtn class="ml-3" :disabled="disableActions" @click="close" variant="tonal" text="Отмена" />
            <VSpacer />
          </VLayout>
        </VLayout>
      </VCardActions>
    </VCard>
  </VForm>
</template>

<script setup lang="ts">
const props = defineProps({
  isActive: Boolean,
  save: Function,
  disableActions: Boolean,
})

const save = () => {
  if(props){
    props.save()
  }
}

const close = () => {
  props.isActive.value = false
}
</script>
