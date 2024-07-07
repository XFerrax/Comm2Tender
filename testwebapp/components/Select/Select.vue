<template>
  <VAutocomplete
    v-if="visible"
    :hide-details="hideDetails"
    :value="value"
    :readonly="readonly"
    :items="selectItems"
    :rules="rules"
    :loading="selectLoading"
    :search-input.sync="selectSearch"
    placeholder="Начните набирать текст для поиска"
    :menu-props="{ transition: 'slide-y-transition' }"
    :item-title="props.itemTitle"
    :item-value="`${props.apiAddress}Id`"
    :clearable="!readonly"
    :prepend-icon="props.prependIcon"
    @input="$emit('input', $event)"
  >
    <template #label>
      <FormLabel :required="rules.includes(requiredRule)" :label="props.label" />
    </template>
  </VAutocomplete>
</template>
<script setup lang="ts">
import FormLabel from '~/components/Control/FormLabel.vue'
import { requiredRule } from '~/utils/validators'
import helpers, { HttpQueryType } from '~/utils/helpers'
import { fetchData } from '~/plugins/api'

const props = defineProps({
  value: {
    type: Number,
    default: 0,
  },
  visible: {
    type: Boolean,
    default: false,
  },
  readonly: {
    type: Boolean,
    default: false,
  },
  hideDetails: {
    type: Boolean,
    default: false,
  },
  rules: {
    type: Array,
    default() {
      return []
    },
  },
  apiAddress: String,
  itemTitle: String,
  label: String,
  prependIcon: {
    type: String,
    default: '',
  },
})

const selectItems = ref([])
const selectLoading = ref(false)
const selectSearch = ref('')
const $helpers = helpers()

onMounted(() => {
  // Загрузка данных при монтировании компонента
  selectLoad()
})

function selectLoad() {
  selectLoading.value = true
  const request = $helpers.BuildQuery(
      HttpQueryType.post, 
      $helpers.getListRequest({}))
      fetchData(`${props.apiAddress}/search`, request) // передайте параметры запроса, если необходимо
        .then((response) => {
          selectItems.value = response.items
        })
        .catch(() => { })
        .finally(() => {
          selectLoading.value = false
        })
}
</script>
