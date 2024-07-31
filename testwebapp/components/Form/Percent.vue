<template>
  <Form v-model:isActive="props.isActive" v-bind:save-func="save" :title="props.title" :title-suffix="props.titleSuffix" :close-func="close" :is-new="props.isNew">
    <template #fields>
      <VDateInput v-model="currentItem.dateEnter" label="Выберите дату начала действия процентов" />
      <VTextField v-model="currentItem.refinancingRate" :rules="[validators.requiredRule, floatRule({ value: currentItem.refinancingRate, rule: myLengthRule(0, 10000)})]" :counter="8">
        <template #label><FormLabel label="Ставка рефинансирования ЦБ РФ" required /></template>
      </VTextField>
      <VTextField v-model="currentItem.tmk" :rules="[validators.requiredRule, floatRule({ value: currentItem.tmk, rule: myLengthRule(0, 10000)})]" :counter="8">
        <template #label><FormLabel label="Процент ТМК" required /></template>
      </VTextField>
      <VTextField v-model="currentItem.bankGuarantee" :rules="[validators.requiredRule, floatRule({ value: currentItem.bankGuarantee, rule: myLengthRule(0, 10000)})]" :counter="8">
        <template #label><FormLabel label="Банковская гарантия" required /></template>
      </VTextField>
      <VTextField v-model="currentItem.credit" :rules="[validators.requiredRule, floatRule({ value: currentItem.credit, rule: myLengthRule(0, 10000)})]" :counter="8">
        <template #label><FormLabel label="Кредитная ставка" required /></template>
      </VTextField>
      <VTextField v-model="currentItem.customDuty" :rules="[validators.requiredRule, validators.floatRule({ value: currentItem.customDuty, rule: myLengthRule(0, 10000)})]" :counter="8">
        <template #label><FormLabel label="Таможенная пошлина" required /></template>
      </VTextField>
      <VTextField v-model="currentItem.discount" :rules="[validators.requiredRule, floatRule({ value: currentItem.discount, rule: myLengthRule(0, 10000)})]" :counter="8">
        <template #label><FormLabel label="Скидка" required /></template>
      </VTextField>
    </template>
  </Form>
</template>

<script setup lang="ts">
import Form from '~/components/Form/Form.vue'
import FormLabel from '~/components/Control/FormLabel.vue'
import { requiredRule, lengthRule, floatRule } from '~/utils/validators'
import helpers, { HttpQueryType } from '~/utils/helpers'
import type { ILengthRule } from '~/utils/helpers'
import { fetchData } from '~/plugins/api'
import { VDateInput } from 'vuetify/labs/VDateInput'
import mixinPropsForm from '~/composables/mixinPropsForm'

const props = defineProps(mixinPropsForm)
const emit = defineEmits(['update:isActive'])

const validators = {
  requiredRule,
  lengthRule,
  floatRule
}

const isActiveForm = ref(props.isActive)

const myLengthRule = (min?: number, max?: number) : ILengthRule => {
  const ret = {}
  if (min) { ret: { min: min } }
  if (max) { ret: { max: max } }
  return ret 
} 

const currentItem = ref({
  percentsDictionaryId: 0,
  dateEnter: null,
  refinancingRate: 0,
  tmk: 0,
  bankGuarantee: 0,
  credit: 0,
  customDuty: 0,
  discount: 0,
})

watch(
  () => props.editedItem,
  (newVal) => {
    currentItem.value.percentsDictionaryId = newVal?.percentsDictionaryId
    currentItem.value.dateEnter = newVal?.dateEnter
    currentItem.value.refinancingRate = newVal?.refinancingRate
    currentItem.value.tmk = newVal?.tmk
    currentItem.value.bankGuarantee = newVal?.bankGuarantee
    currentItem.value.credit = newVal?.credit
    currentItem.value.customDuty = newVal?.customDuty
    currentItem.value.discount = newVal?.discount
})

const save = () => {
  const item = {
    percentsDictionaryId: currentItem.value.percentsDictionaryId,
    dateEnter: currentItem.value.dateEnter,
    refinancingRate: currentItem.value.refinancingRate,
    tmk: currentItem.value.tmk,
    bankGuarantee: currentItem.value.bankGuarantee,
    credit: currentItem.value.credit,
    customDuty: currentItem.value.customDuty,
    discount: currentItem.value.discount
  }
  
  const $helpers = helpers()
  const request = $helpers.BuildQuery(props.isNew ? HttpQueryType.post : HttpQueryType.put, item)
  if (props.isNew) {
    fetchData(props.apiAddress!, request)
      .then(() => {
        isActiveForm.value = false
      })
  } else {
    fetchData(`${props.apiAddress!}/${item.percentsDictionaryId}`, item)
      .then(() => {
        isActiveForm.value = false
      })
  }
}

const close = () => {
  emit('update:isActive', false)
}
</script>

