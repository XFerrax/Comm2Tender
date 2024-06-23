<template>
  <v-form ref="form" v-model="valid" lazy-validation @submit.prevent="login">
    <v-card class="elevation-12 my-2 mx-auto w-50">
      <v-toolbar dark color="primary" class="flex-grow-0">
        <v-toolbar-title>Вход в систему</v-toolbar-title>
      </v-toolbar>
      <v-card-text>
        <v-text-field
          v-model="currentItem.email"
          :rules="[valudators.requiredRule, valudators.emailRule]"
          prepend-icon="mdi-account"
          label="Email"
          required
          autocomplete="email"
        />
        <v-text-field
          v-model="currentItem.password"
          :rules="[valudators.requiredRule]"
          prepend-icon="mdi-lock"
          label="Пароль"
          required
          type="password"
          autocomplete="current-password"
        />
      </v-card-text>
      <v-card-actions class="pa-4">
        <v-layout justify-center>
          <v-btn :disabled="!valid" color="primary" type="submit"> Войти </v-btn>
        </v-layout>
      </v-card-actions>
    </v-card>
  </v-form>
</template>

<script lang="ts" setup>
  import { useAuthStore } from '~/store/auth.store'
  import { requiredRule, emailRule } from '~/utils/validators'

  const valid = ref(false)
  const form = ref({validate(){return false}})
  const currentItem = ref({
    email: 'testadmin@tmk-group.com',
    password: 'FiRK2M%7Q$cqgMz@',
  })

  const valudators = {
    requiredRule,
    emailRule,
  }

  
  // Определение метода login
  const login = () => {
    if(form.value.validate()) {
      useAuthStore().login(
        currentItem.value.email, 
        currentItem.value.password, 
        useRouter())
    }
  }
</script>