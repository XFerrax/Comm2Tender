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
      <VTextField v-model="currentItem.number" :rules="[validators.requiredRule, validators.lengthRule(currentItem.number, lengthRule50)]" :counter="50">
        <template #label>
          <FormLabel label="Номер тендера" required />
        </template>
      </VTextField>
      <VTextField v-model="currentItem.discription" :rules="[validators.requiredRule, validators.emailRule(currentItem.discription)]">
        <template #label>
          <FormLabel label="Описание" required />
        </template>
      </VTextField>
      <Select
        v-model="currentItem.percentsDictionaryId"
        :visible="true"
        :rules="[validators.requiredRule]"
        api-address="percentsDictionary"
        item-title="name"
        label="Набор процентных ставок" 
      ></Select>
      <Select
        v-model="currentItem.winnerProposalId"
        :visible="true"
        api-address="agent"
        item-title="name"
        label="Контрагент" 
      ></Select>
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
const emit = defineEmits(['update:isActive'])

const validators = {
  requiredRule,
  lengthRule,
  emailRule,
}

const lengthRule50 : ILengthRule = { max: 50 }

const currentItem = ref({
  tenderId: 0,
  number: '',
  discription: '',
  percentsDictionaryId: 0,
  winnerProposalId: 0,
})

watch(
  () => props.editedItem,
  (newVal) => {
    currentItem.value.tenderId = newVal?.tenderId
    currentItem.value.number = newVal?.number
    currentItem.value.discription = newVal?.discription
    currentItem.value.percentsDictionaryId = newVal?.percentsDictionary?.percentsDictionaryId
    currentItem.value.winnerProposalId = newVal?.winnerProposal?.winnerProposalId
})

const save = () => {
  const item = {
    tenderId: currentItem.value.tenderId,
    number: currentItem.value.number,
    discription: currentItem.value.discription,
    percentsDictionary: {
      percentsDictionaryId: currentItem.value.percentsDictionaryId,
    },
    winnerProposal: null as { winnerProposalId: number; } | null,
  }

  if(currentItem.value.winnerProposalId > 0)
  {
    item.winnerProposal = {
      winnerProposalId: currentItem.value.winnerProposalId,
    }
  }
  
  const $helpers = helpers()
  const request = $helpers.BuildQuery(props.isNew ? HttpQueryType.post : HttpQueryType.put, item)
  if (props.isNew) {
    fetchData(props.apiAddress!, request)
      .then(() => {
        close()
      })
  } else {
    fetchData(`${props.apiAddress!}/${item.tenderId}`, item)
      .then(() => {
        close()
      })
  }
}

const close = () => {
  emit('update:isActive', false)
}
</script>

