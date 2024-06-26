<template>
  <Form
    v-model:isActive="props.isActive"
    v-bind:save-func="save"
    :title="props.title"
    :title-suffix="props.titleSuffix"
    :close-func="close"
    :is-new="props.isNew"
  >
    <template #fields>
      <VTextField v-model="currentItem.minAmount" :rules="[validators.requiredRule]" :counter="50">
        <template #label>
          <FormLabel label="Нижняя граница действия пошлины" required />
        </template>
      </VTextField>
      <VTextField v-model="currentItem.summaryCustomFee" :rules="[validators.requiredRule]">
        <template #label>
          <FormLabel label="Пошлина" required />
        </template>
      </VTextField>
    </template>
  </Form>
</template>

<script setup lang="ts">
import Form from '~/components/Form/Form.vue'
import FormLabel from '~/components/Control/FormLabel.vue'
import Select from '~/components/Select/Select.vue'
import { requiredRule, lengthRule, emailRule } from '~/utils/validators'
import helpers from '~/utils/helpers'
import type { ILengthRule } from '~/utils/helpers'
import { fetchData } from '~/plugins/api'

const props = defineProps(mixinPropsForm)
const emit = defineEmits(['update:isActive'])

const validators = {
  requiredRule,
  lengthRule,
  emailRule,
}

const isActiveForm = ref(props.isActive)

const lengthRule50 : ILengthRule = { max: 50 }

const currentItem = ref({
  customFeeDictionaryId: 0,
  minAmount: 0,
  summaryCustomFee: 0,
})

watch(
  () => props.editedItem,
  (newVal) => {
    currentItem.value.customFeeDictionaryId = newVal?.customFeeDictionaryId
    currentItem.value.minAmount = newVal?.minAmount
    currentItem.value.summaryCustomFee = newVal?.summaryCustomFee
})

const save = () => {
  const item = {
    customFeeDictionaryId: currentItem.value.customFeeDictionaryId,
    minAmount: currentItem.value.minAmount,
    summaryCustomFee: currentItem.value.summaryCustomFee,
  }
  
  const $helpers = helpers()
  const request = $helpers.BuildQuery(props.isNew ? HttpQueryType.post : HttpQueryType.put, item)
  if (props.isNew) {
    fetchData(props.apiAddress!, request)
      .then(() => {
        isActiveForm.value = false
      })
  } else {
    fetchData(`${props.apiAddress!}/${item.customFeeDictionaryId}`, item)
      .then(() => {
        isActiveForm.value = false
      })
  }
}

const close = () => {
  emit('update:isActive', false)
}
</script>

