<template>
  <Form
    v-bind:isActive="props.isActive"
    :save="save"
  >
    <template #fields>
      
    </template>
  </Form>
</template>

<script setup lang="ts">
import Form from '~/components/Form/Form.vue'
import FormLabel from '~/components/Control/FormLabel.vue'
import RoleSelect from '~/components/Select/Role.vue'
import { requiredRule, lengthRule, emailRule } from '~/utils/validators'
import helpers from '~/utils/helpers'
import type { ILengthRule } from '~/utils/helpers'
import { fetchData } from '~/plugins/api'

const props = defineProps({
  isActive: Boolean,
  isNew: Boolean,
  editedItem: Object,
})

const validators = {
  requiredRule,
  lengthRule,
  emailRule,
}

const isActiveForm = ref(props.isActive)

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
  currentItem.value.roleId = props.editedItem.role.roleId
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
  const request = $helpers.BuildQuery(HttpQueryType.post, item)
  if (props.isNew) {
    fetchData('user', request)
      .then(() => {
        isActiveForm.value = false
      })
  } else {
    fetchData(`user/${item.userId}`, item)
      .then(() => {
        isActiveForm.value = false
      })
  }
}
</script>

