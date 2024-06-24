<template>
  <VDialog v-model="props.isActive" transition="dialog-top-transition" max-width="800">
    <VForm ref="form" fast-fail>
      <VCard class="elevation-10">
        <VToolbar color="primary" class="flex-grow-0">
          <VToolbarTitle>{{ textTitle() }}</VToolbarTitle>
          <VSpacer />
          <VToolbarItems>
            <VBtn density="comfortable" variant="tonal" @click="props.closeFunc" icon="mdi-close" />
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
              <VBtn color="primary" variant="tonal" @click="props.saveFunc" text="Сохранить" />
              <VBtn class="ml-3" :disabled="disableActions" @click="props.closeFunc" variant="tonal" text="Отмена" />
              <VSpacer />
            </VLayout>
          </VLayout>
        </VCardActions>
      </VCard>
    </VForm>
  </VDialog>
</template>

<script setup lang="ts">
import mixinPropsForm from '~/composables/mixinPropsForm';

const props = defineProps(mixinPropsForm)

const textTitle = () => {
  if(props.title && props.title != '') {
    return props.title
  }
  else if (props.titleSuffix && props.titleSuffix != '') {
    return (props.isNew ? 'Добавление' : 'Редактирование') + ' ' + props.titleSuffix
  }
  return ''
}
</script>
