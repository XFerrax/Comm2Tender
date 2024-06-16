<template>
  <v-layout v-if="visible" wrap class="pt-4">
    <v-container v-if="!hideFilter" fluid class="pt-0 pb-2 px-0 ma-0">
      <v-row no-gutters class="px-4 pb-2 mt-n2">
        <v-col v-if="!hideSearch" cols="7" :sm="6" :md="5" :lg="4" :xl="3" class="mr-4">
          <v-text-field
            v-model="mixinSearch"
            :label="$store.state.text.searchLabel"
            prepend-icon="search"
            single-line
            hide-details
            clearable
            @keydown.enter="load"
          />
        </v-col>
        <v-col v-if="!hideSearch" cols="auto">
          <v-btn :disabled="mixinLoading" class="mt-3" @click="load">
            <v-icon left>mdi-refresh</v-icon>
            {{ $store.state.text.searchButton }}
          </v-btn>
        </v-col>
      </v-row>
    </v-container>

    <v-container v-if="!readonly" fluid class="pa-0 ma-0">
      <v-row no-gutters class="px-2">
        <v-col cols="auto">
          <v-btn color="primary" class="mx-2 mb-4" @click="mixinAdd">
            {{ $store.state.text.addButton }}
          </v-btn>
        </v-col>
      </v-row>
    </v-container>

    <v-container fluid class="pa-0 ma-0">
      <v-row no-gutters>
        <v-col>
          <v-divider />
          <v-data-table
            v-model="mixinSelected"
            :show-select="selectMulti"
            :headers="headers"
            :items="mixinItems"
            :footer-props="{
              'items-per-page-options': $store.state.rowsPerPageItems,
            }"
            :options.sync="mixinPagination"
            :server-items-length="mixinTotal"
            :loading="mixinLoading"
            :item-key="itemKey"
          >
            <template #[`item.role`]="{ item }">
              {{ item.role ? item.role.name : '' }}
            </template>
            <template #[`item.member.alias`]="{ item }">
              {{ item.member ? item.member.alias : '' }}
            </template>
            <template #[`item.actions`]="{ item }">
              <v-row no-gutters align="center" justify="center" class="flex-nowrap">
                <v-tooltip bottom :open-delay="1000" :close-delay="0">
                  <template #activator="{ on }">
                    <v-btn icon class="mx-1" outlined color="warning" v-on="on" @click="entranceUser(item)">
                      <v-icon>mdi-exit-to-app</v-icon>
                    </v-btn>
                  </template>
                  <span>{{ userEntrence }}</span>
                </v-tooltip>
                <v-menu offset-x offset-y nudge-left="20px" nudge-top="20px">
                  <!-- появление под курсором вместо появления в указанном месте (absolute вместо nudge-left="20px" nudge-top="20px") -->
                  <!-- @click.stop нужно для того чтобы не сработал tr @click -->
                  <template #activator="{ on: menu }">
                    <v-tooltip bottom :open-delay="1000" :close-delay="0">
                      <template #activator="{ on: tooltip }">
                        <v-btn icon class="mx-1" outlined color="primary" v-on="{ ...tooltip, ...menu }" @click.stop="mixinMenuItem(item)">
                          <v-icon>mdi-menu</v-icon>
                        </v-btn>
                      </template>
                      <span>Меню</span>
                    </v-tooltip>
                  </template>
                  <v-list>
                    <v-list-item @click="userBlockingVisible = true">
                      <v-list-item-title>Блокировки пользователя</v-list-item-title>
                    </v-list-item>
                    <v-list-item @click="userApiTokenVisible = true">
                      <v-list-item-title>Ключи доступа к API</v-list-item-title>
                    </v-list-item>
                  </v-list>
                </v-menu>
                <v-tooltip bottom :open-delay="1000" :close-delay="0">
                  <template #activator="{ on }">
                    <v-btn icon class="mx-1" outlined color="primary" v-on="on" @click="mixinEditItem(item)">
                      <v-icon>mdi-pencil</v-icon>
                    </v-btn>
                  </template>
                  <span>{{ $store.state.text.editButton }}</span>
                </v-tooltip>
                <v-tooltip bottom :open-delay="1000" :close-delay="0">
                  <template #activator="{ on }">
                    <v-btn icon class="mx-1" outlined color="error" v-on="on" @click="mixinDeleteItem(item)">
                      <v-icon>mdi-delete</v-icon>
                    </v-btn>
                  </template>
                  <span>{{ $store.state.text.deleteButton }}</span>
                </v-tooltip>
              </v-row>
            </template>
            <template #no-data>
              <MyAlert :text="$store.state.text.noData" icon="mdi-alert-circle-outline" outlined />
            </template>
          </v-data-table>
        </v-col>
      </v-row>
    </v-container>

    <UserForm
      v-if="!readonly"
      v-model="mixinEditedItem"
      :visible.sync="mixinForm"
      :is-new="mixinIsNew"
      @before-request="mixinBeforeRequest"
      @saved="saved"
    />

    <DialogComponent
      v-if="!readonly"
      :visible.sync="userBlockingVisible"
      :title="'История блокировок пользователя - ' + description"
      :max-width="$store.state.dialogWidthL"
    >
      <UserBlockingCrud :visible="userBlockingVisible" :user-id="mixinEditedItem ? mixinEditedItem.userId : 0" hide-filter />
    </DialogComponent>

    <DialogComponent
      v-if="!readonly"
      :visible.sync="userApiTokenVisible"
      :title="'Ключи доступа к API - ' + description"
      :max-width="$store.state.dialogWidthXL"
    >
      <UserApiTokenCrud :visible="userApiTokenVisible" :user-id="mixinEditedItem ? mixinEditedItem.userId : 0" hide-filter />
    </DialogComponent>
  </v-layout>
</template>

<script setup lang="ts">
import mixinCrud from '~/assets/mixinCrud';
import UserForm from '~/components/Form/User.vue';
import UserBlockingCrud from '~/components/Crud/UserBlocking.vue';
import UserApiTokenCrud from '~/components/Crud/UserApiToken.vue';
import { ref } from 'vue';

const userEntrance = 'Вход под пользователем';
let userBlockingVisible = ref(false);
let userApiTokenVisible = ref(false);
const itemKey = 'userId';

const headers = [
  { text: 'ID пользователя', value: 'userId' },
  { text: 'Роль', value: 'role' },
  { text: 'Участник системы', value: 'member.alias' },
  { text: 'ФИО', value: 'name' },
  { text: 'E-mail', value: 'email' },
  { text: 'Телефон', value: 'phone' },
  // { text: 'Пароль', value: 'password' },
];

const description = computed(() => {
  let text = '';
  if (mixinEditedItem.value) {
    text = `ID:${mixinEditedItem.value.userId}`;
    if (mixinEditedItem.value.member) {
      text += `, ${mixinEditedItem.value.member.alias}`;
    }
    text += `, ${mixinEditedItem.value.email}`;
  }
  return text;
});

function created() {
  if (!readonly) {
    headers.push({
      text: 'Действия',
      align: 'center',
      sortable: false,
      value: 'actions',
    });
  }
}

function load(id) {
  if (!mixinLoading.value) {
    mixinBeforeRequest();
    $axios
      .$post(
        'user/search',
        $helpers.getListRequest({
          pagination: mixinPagination,
          search: mixinSearch,
        })
      )
      .then((response) => {
        mixinItems.value = response.items;
        mixinTotal.value = response.total;
        mixinAfterRequest(true);
      });
  }
}

function entranceUser(value) {
  const item = {
    login: value.email,
    password: value.password,
  };
  $axios
    .$post('auth/login', item)
    .then((response) => {
      if (response.accessToken && response.refreshToken) {
        window.open(`https://lk.kvitel.ru/redirect.html?at=${response.accessToken}&rt=${response.refreshToken}`, '_blank');
      }
    })
    .catch((error) => {
      const code = parseInt(error.response && error.response.status);
      if (code === 401) {
        if (error.response && error.response.data && error.response.data.message) {
          $helpers.toastError({
            message: error.response.data.message,
          });
        }
      }
    });
}

function saved(id, isAdd) {
  mixinAfterRequest(isAdd);
  if (isAdd) {
    load(id);
  }
}

function deleteUser() {
  mixinBeforeRequest();
  $axios.$delete(`user/${mixinEditedItem.value.userId}`).then(() => {
    $helpers.toastSuccess({
      message: $store.state.text.deleted,
    });
    mixinAfterRequest();
  });
}
</script>