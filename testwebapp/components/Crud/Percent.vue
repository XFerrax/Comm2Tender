<template>
  <VLayout v-if="visible" wrap>
    <VCard :title="title" flat width="100%">
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
                class="align-self-center"
                @click="showForm"
                text="Добавить"
              />
            </VCol>
          </VRow>          
        </VContainer>
      </template>
      <VDivider />
      <VDataTable
        :show-select="selectMulti"
        :headers="headers"
        :items="useCrud.items.value"
        :footer-props="{
          'Элементов на странице': 10,
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
  <Form
    v-model:isActive="useCrud.isForm.value"
    v-bind:title-suffix="titleSuffixForm"
    :is-new="useCrud.isNew.value"
    :edited-item="useCrud.editedItem"
    :api-address="apiAddress"
  />
  <DialogConfirm
    :isOpen="useCrud.isDialogConfirm.value"
    @confirm="deleteItem"
    @cancel="useCrud.isDialogConfirm.value = false"
  />
</template>

<script setup lang="ts">
import mixinPropsCrud from '~/composables/mixinPropsCrud'
import mixinUseCrud from '~/composables/mixinUseCrud'
import { ref } from 'vue'
import MyAlert from '~/components/Control/MyAlert.vue'
import DialogConfirm from '~/components/Dialog/DialogConfirm.vue'
import helpers from '~/utils/helpers'
import { fetchData } from '~/plugins/api'
import Form from '~/components/Form/Percent.vue'

var props = defineProps(mixinPropsCrud)
const useCrud = mixinUseCrud()

const $helpers = helpers()
const apiAddress = 'percentsDictionary'
const itemKey = `${apiAddress}Id`
const title = 'Процентные ставки'
const titleSuffixForm = 'процентных ставок'

const headers = ref([
  { title: 'ID процентных ставок', key: itemKey, align: 'end', sortable: true, },
  { title: 'Ставка ЦБ', key: 'refinancingRate', align: 'start', sortable: true, },
  { title: '% ТМК', key: 'tmk', align: 'start', sortable: true, },
  { title: 'Банковская гарантия', key: 'bankGuarantee', align: 'start', sortable: true, },
  { title: 'Кредит', key: 'credit', align: 'center', sortable: false, },
  { title: 'Таможенная пошлина', key: 'customDuty', align: 'center', sortable: false, },
  { title: 'Скидка', key: 'discount', align: 'center', sortable: false, },
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

const load = () => {
  if (!useCrud.loading.value) {
    useCrud.mixinBeforeRequest()
    const request = $helpers.BuildQuery(
      HttpQueryType.post, 
      $helpers.getListRequest(
      {
        pagination: useCrud.pagination.value,
        search: useCrud.search.value,
      }))
    fetchData(`${apiAddress}/search`, request)
      .then(response => {
        useCrud.items = ref<any[]>(response.items)
        useCrud.total = response.total
        useCrud.mixinAfterRequest(true)
      })
  }
}

const deleteItem = () => {
  const request = $helpers.BuildQuery(HttpQueryType.delete)
  fetchData(`${apiAddress}/${useCrud.editedItem.value.percentsDictionaryId}`, request)
    .then(response => {
      useCrud.items = ref<any[]>(response.items)
      useCrud.total = response.total
      useCrud.mixinAfterRequest(true)
    })
}

const showForm = () => {
  useCrud.isNew.value = true
  useCrud.isForm.value = true
}
</script>