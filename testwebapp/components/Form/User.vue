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
      <Select
        v-model="currentItem.roleId"
        :visible="true"
        :rules="[validators.requiredRule]"
        api-address="role"
        item-title="name"
        label="Роль" 
      ></Select>
      <VCheckbox v-model="currentItem.isActive" label="Активация учетной записи" />
    </template>
  </Form>
</template>

<script setup lang="ts">
import Form from '~/components/Form/Form.vue'
import FormLabel from '~/components/Control/FormLabel.vue'
import Select from '~/components/Select/Select.vue'
import { requiredRule, lengthRule, emailRule } from '~/utils/validators'
import helpers, { HttpQueryType } from '~/utils/helpers'
import type { ILengthRule } from '~/utils/helpers'
import { fetchData } from '~/plugins/api'
import mixinPropsForm from '~/composables/mixinPropsForm';

const props = defineProps(mixinPropsForm)
const emit = defineEmits(['update:isActive','saved'])

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

watch(() => props.editedItem, (newVal) => {
  if (props.isNew) {
    currentItem.value = {
      userId: 0,
      name: '',
      email: '',
      password: '',
      roleId: 0,
      isActive: false,
    };
  } else {
    currentItem.value.userId = newVal?.userId;
    currentItem.value.name = newVal?.name;
    currentItem.value.email = newVal?.email;
    currentItem.value.password = newVal?.password;
    currentItem.value.roleId = newVal?.role?.roleId;
    currentItem.value.isActive = newVal?.isActive;
  }
});

const save = () => {
  const item = {
    UserId: currentItem.value.userId,
    Name: currentItem.value.name,
    Email: currentItem.value.email,
    Password: currentItem.value.password,
    Role: {
      Name: "",
      RoleId: currentItem.value.roleId,
    },
    IsActive: currentItem.value.isActive
  }
  
  const $helpers = helpers()
  const request = $helpers.BuildQuery(props.isNew ? HttpQueryType.post : HttpQueryType.put, item)
  if (props.isNew) {
    fetchData(props.apiAddress!, request)
      .then(() => {
        emit('saved');
        close()
      })
  } else {
    fetchData(props.apiAddress!, request)
      .then(() => {
        emit('saved');
        close()
      })
  }
}

const close = () => {
  emit('update:isActive', false)
}
</script>

