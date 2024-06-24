<template>
  <Form
    v-model:isActive="props.isActive"
    v-bind:save-func="props.saveFunc"
    :title="props.title"
    :title-suffix="props.titleSuffix"
    :close-func="close"
    :is-new="props.isNew"
  >
    <template #fields>
      <VTextField v-model="currentItem.name" :rules="[validators.requiredRule, validators.lengthRule(currentItem.name, lengthRule50)]" :counter="50">
        <template #label>
          <FormLabel label="ФИО" required />
        </template>
      </VTextField>
      <VTextField v-model="currentItem.email" :rules="[validators.requiredRule, validators.emailRule(currentItem.email)]">
        <template #label>
          <FormLabel label="E-mail" required />
        </template>
      </VTextField>
      <VTextField
        v-model="currentItem.password"
        :rules="[validators.requiredRule, validators.lengthRule(currentItem.password, lengthRule50)]"
        :counter="50"
      >
        <template #label>
          <FormLabel label="Пароль" required />
        </template>
      </VTextField>
      <RoleSelect v-model="currentItem.roleId" :visible="true" :rules="[validators.requiredRule]" />
      <VCheckbox v-model="currentItem.isActive" label="Активация учетной записи" />
    </template>
  </Form>
</template>

<script setup lang="ts">
import Form from '~/components/Form/Form.vue'
import FormLabel from '~/components/Control/FormLabel.vue'
import RoleSelect from '~/components/Select/Role.vue'
import { requiredRule, lengthRule, emailRule } from '~/utils/validators'
import helpers, { HttpQueryType } from '~/utils/helpers'
import type { ILengthRule } from '~/utils/helpers'
import { fetchData } from '~/plugins/api'
import mixinPropsForm from '~/composables/mixinPropsForm';

const props = defineProps(mixinPropsForm)
const emit = defineEmits(['update:isActive'])

const validators = {
  requiredRule,
  lengthRule,
  emailRule,
}

const lengthRule50 : ILengthRule = { max: 50 }

const currentItem = ref({
  userId: 0,
  name: '',
  email: '',
  password: '',
  roleId: 0,
  isActive: false,
})

if(props.editedItem) {
  currentItem.value.userId = props.editedItem.userId
  currentItem.value.name = props.editedItem.name
  currentItem.value.email = props.editedItem.email
  currentItem.value.password = props.editedItem.password
  currentItem.value.roleId = props.editedItem.role?.roleId
  currentItem.value.isActive = props.editedItem.isActive
}

const save = () => {
  const item = {
    userId: currentItem.value.userId,
    name: currentItem.value.name,
    email: currentItem.value.email,
    password: currentItem.value.password,
    role: {
      roleId: currentItem.value.roleId,
      name: '',
    
    },
    isActive: currentItem.value.isActive,
  }
  
  const $helpers = helpers()
  const request = $helpers.BuildQuery(props.isNew ? HttpQueryType.post : HttpQueryType.put, item)
  if (props.isNew) {
    fetchData('user', request)
      .then(() => {
        close()
      })
  } else {
    fetchData(`user/${item.userId}`, item)
      .then(() => {
        close()
      })
  }
}

const close = () => {
  emit('update:isActive', false)
}
</script>

