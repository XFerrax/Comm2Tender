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
      <VTextField v-model="currentItem.name" :rules="[validators.requiredRule]" :counter="50">
        <template #label>
          <FormLabel label="Название контрагента" required />
        </template>
      </VTextField>
      <VDateInput
        v-model="currentItem.agentRegistrationDate"
        label="Выберите дату регистрации контрагента"
      />
      <VTextField v-model="currentItem.ogrn" :rules="[validators.requiredRule]">
        <template #label>
          <FormLabel label="ОГРН" required /> //Длина 13 цифр
        </template>
      </VTextField>
      <VTextField
        v-model="currentItem.inn"
        :rules="[validators.requiredRule]"
        :counter="50"
      >
        <template #label>
          <FormLabel label="ИНН" required /> //Длина 10 или 12 цифр
        </template>
      </VTextField>
      <VTextField v-model="currentItem.kpp" :rules="[validators.requiredRule]" :counter="50">
        <template #label>
          <FormLabel label="КПП" required /> //Длина 9 цифр
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
  agentId: 0,
  name: '',
  agentRegistrationDate: null,
  agentSystemRegistrationDate: null,
  ogrn: 0,
  inn: 0,
  kpp: 0,
})

if(props.editedItem) {
  currentItem.value.agentId = props.editedItem.agentId
  currentItem.value.name = props.editedItem.name
  currentItem.value.agentRegistrationDate = props.editedItem.agentRegistrationDate
  currentItem.value.agentSystemRegistrationDate = props.editedItem.agentSystemRegistrationDate
  currentItem.value.ogrn = props.editedItem.role.ogrn
  currentItem.value.inn = props.editedItem.inn
  currentItem.value.kpp = props.editedItem.kpp
}

const save = () => {
  const item = {
    agentId: currentItem.value.agentId,
    name: currentItem.value.name,
    agentRegistrationDate: currentItem.value.agentRegistrationDate,
    agentSystemRegistrationDate: currentItem.value.agentSystemRegistrationDate,
    ogrn: currentItem.value.ogrn,
    inn: currentItem.value.inn,
    kpp: currentItem.value.kpp,
  }
  
  const $helpers = helpers()
  const request = $helpers.BuildQuery(props.isNew ? HttpQueryType.post : HttpQueryType.put, item)
  if (props.isNew) {
    fetchData(props.apiAddress!, request)
      .then(() => {
        isActiveForm.value = false
      })
  } else {
    fetchData(`${props.apiAddress!}/${item.agentId}`, item)
      .then(() => {
        isActiveForm.value = false
      })
  }
}

const close = () => {
  emit('update:isActive', false)
}
</script>

