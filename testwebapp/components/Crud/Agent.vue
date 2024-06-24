<template>
  <VLayout v-if="visible" wrap>
    <VCard title="Контрагенты" flat width="100%">
      <template v-slot:text>
        <VContainer>
          <VRow>
            <VCol class="d-flex justify-center" cols="6">
              <VTextField
                v-if="!hideSearch"
                v-model="useCrud.search.value"
                label="Поиск"
                prepend-icon="mdi-magnify"
                single-line
                hide-details
                clearable
                @keydown.enter="load"
              />
            </VCol>
            <VCol class="d-flex justify-center">
              <VBtn 
                v-if="!hideSearch"
                :disabled="useCrud.loading.value" 
                prepend-icon="mdi-refresh"
                class="align-self-center"
                text="Поиск"
                @click="load"
              />
            </VCol>
            <VSpacer />
            <VCol class="d-flex justify-center">
              <VBtn 
                v-if="!readonly"
                color="primary" 
                prepend-icon="mdi-plus"
                class="align-self-center">
                Добавить
                <VDialog activator="parent" max-width="800">
                  <template v-slot:default="{ isActive }">
                    <Form
                      v-bind:isActive="isActive"
                      is-new
                    />
                  </template>
                </VDialog>
              </VBtn>
            </VCol>
          </VRow>          
        </VContainer>
      </template>
      <VDivider />
      <VDataTable
        v-model="useCrud.selected"
        :show-select="selectMulti"
        :headers="headers"
        :items="useCrud.items.value"
        :footer-props="{
          'items-per-page-options': 10,
        }"
        :options.sync="useCrud.pagination"
        :server-items-length="useCrud.total"
        :loading="useCrud.loading.value"
        :item-key="itemKey"
      >
        <template #["item.isActive"]="{ item }">
          <v-icon 
            :icon="item.isActive ? 'mdi-check-circle-outline' : 'mdi-close-circle-outline'" 
            :color="item.isActive ? 'green' : 'red'"
          />
        </template>
        <template #[`item.actions`]="{ item }">
          <VRow no-gutters align="center" justify="center" class="flex-nowrap">
            <VTooltip
              location="bottom"
              :open-delay="1000"
              :close-delay="0"
              text="Редактировать"
              >
              <template #activator="{ props }">
                <VBtn
                  density="comfortable"
                  icon
                  class="mx-1"
                  variant="tonal"
                  color="primary"
                  v-bind="props"
                  @click="useCrud.mixinEditItem(item)"
                >
                  <VIcon>mdi-pencil</VIcon>
                  <VDialog activator="parent" max-width="800">
                    <template v-slot:default="{ isActive }">
                      <Form
                        v-bind:isActive="isActive"
                        is-new="false"
                        :edited-item="item"
                      />
                    </template>
                  </VDialog>
                </VBtn>
              </template>
            </VTooltip>
            <VTooltip location="bottom" :open-delay="1000" :close-delay="0" text="Удалить">
              <template #activator="{ props }">
                <VBtn 
                  density="comfortable" 
                  icon
                  class="mx-1" 
                  variant="tonal" 
                  color="error" 
                  v-bind="props" 
                  @click="useCrud.mixinDeleteItem(item)"
                >
                  <VIcon>mdi-delete</VIcon>
                  <VDialog activator="parent">
                    <VCard>
                      <VCardTitle class="text-h5">Удалить выбранного контрагента?</VCardTitle>
                      <VCardActions>
                        <VSpacer />
                        <VBtn variant="text" @click="deleteItemConfirm">OK</VBtn>
                        <VBtn variant="text" @click="closeDelete">Cancel</VBtn>
                        <VSpacer />
                      </VCardActions>
                    </VCard>
                  </VDialog>
                </VBtn>
              </template>
            </VTooltip>
          </VRow>
        </template>
        <template #no-data>
          <MyAlert text="Нет данных" icon="mdi-alert-circle-outline" outlined />
        </template>
      </VDataTable>
    </VCard>

  </VLayout>
</template>

<script setup lang="ts">
import mixinPropsCrud from '~/composables/mixinPropsCrud'
import mixinUseCrud from '~/composables/mixinUseCrud'
import { ref } from 'vue'
import MyAlert from '~/components/Control/MyAlert.vue'
import helpers from '~/utils/helpers'
import { fetchData } from '~/plugins/api'
import Form from '~/components/Form/Agent.vue'

var props = defineProps(mixinPropsCrud)
const useCrud = mixinUseCrud()
const $helpers = helpers()
const addBtn = ref(null)
const itemKey = 'agentId'

const headers = ref([
  { title: 'ID агента', key: itemKey, align: 'end', sortable: true, },
  { title: 'Название', key: 'name', align: 'start', sortable: true, },
  { title: 'ИНН', key: 'inn', align: 'start', sortable: true, },
  { title: 'КПП', key: 'kpp', align: 'start', sortable: true, },
  { title: 'ОГРН', key: 'ogrn', align: 'start', sortable: true, },
  { title: 'Дата регистрации', key: 'agentRegistrationDate', align: 'start', sortable: true, },
])

if (!props.readonly) {
  headers.value.push({
    title: 'Действия',
    key: 'actions',
    align: 'center',
    sortable: false,
  })
}

onMounted(() => load())

function load() {
  if (!useCrud.loading.value) {
    useCrud.mixinBeforeRequest()
    const request = $helpers.BuildQuery(
      HttpQueryType.post, 
      $helpers.getListRequest(
      {
        pagination: useCrud.pagination.value,
        search: useCrud.search.value,
      }))
    fetchData('agent/search', request)
      .then(response => {
        useCrud.items = ref<any[]>(response.items)
        useCrud.total = response.total
        useCrud.mixinAfterRequest(true)
      })
  }
}

function saved() {

}

const close = () => {
  addBtn.value = null
}
</script>