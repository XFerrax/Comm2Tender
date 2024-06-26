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
      <Select
        v-model="currentItem.agentId"
        :visible="true"
        :rules="[validators.requiredRule]"
        api-address="agent"
        item-title="name"
        label="Контрагент" 
      />
      <Select
        v-model="currentItem.tenderId"
        :visible="true"
        :rules="[validators.requiredRule]"
        api-address="tender"
        item-title="number"
        label="Тендер" 
      />
      <VDivider />
      <VCardText>Объем закупки</VCardText>
      <VTextField
          label="Количество товара(услуг), ед"
          prepend-icon="mdi-briefcase-account"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.countPos"
      />
      <VTextField
          label="Стоимость 1 ед товара(услуги)"
          prepend-icon="mdi-briefcase-account"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.positionPrice"
      />
      <VTextField
          label="Стоимость доставки, руб."
          prepend-icon="mdi-cash"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.deliveryCost"
      />
      <VTextField
          label="Сроки поставки, дн"
          prepend-icon="mdi-timer-settings-outline"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.deliveryTime"
      >
          <VTooltip 
              activator="parent"
              location="top"
              text="Количество дней между датой заключения договора(или первого аванса) и даты поставки товара. Шаг рассчета 5 дней" />
      </VTextField>
      <VDivider />
      <VCardText>Условия оплаты</VCardText>
      
      <VTextField
          label="Аванс 1"
          prepend-icon="mdi-cash"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.prepaidExpense1"
      />
      
      <VTextField
          label="Аванс 2"
          prepend-icon="mdi-cash"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.prepaidExpense2"
      />
      <VTextField
          label="Аванс 3"
          prepend-icon="mdi-cash"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.prepaidExpense3"
      />
      
      <VTextField
          label="Срок аванса 1, дн"
          prepend-icon="mdi-timer-settings-outline"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.periodOfExecution1"
      >
          <VTooltip text="Количество дней между датой аванса и датой поступления товара на склад. Шаг рассчета 5 дней" />
      </VTextField>
      <VTextField
          label="Срок аванса 2, дн"
          prepend-icon="mdi-timer-settings-outline"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.periodOfExecution2"
      />
      <VTextField
          label="Срок аванса 3, дн"
          prepend-icon="mdi-timer-settings-outline"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.periodOfExecution3"
      />

      <VTextField
          label="Постоплата 1, %"
          prepend-icon="mdi-cash-100"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.postPaymant1"
      />
      <VTextField
          label="Постоплата 2, %"
          prepend-icon="mdi-cash-100"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.postPaymant2"
      />
      <VTextField
          label="Постоплата 3, %"
          prepend-icon="mdi-cash-100"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.postPaymant3"
      />
      <VTextField
          label="Срок постоплаты 1, дн"
          prepend-icon="mdi-timer-settings-outline"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.postPaymantPeriod1"
      >
          <VTooltip text="Количество дней между датой поставки товаров и планируемой датой постоплаты. Шаг рассчета 5 дней" />
      </VTextField>
      <VTextField
          label="Срок постоплаты 2, дн"
          prepend-icon="mdi-timer-settings-outline"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.postPaymantPeriod2"
      />
      <VTextField
          label="Срок постоплаты 3, дн"
          prepend-icon="mdi-timer-settings-outline"
          variant="outlined"
          :rules="[validators.requiredRule]"
          v-model="currentItem.postPaymantPeriod3"
      />
      <VDivider />
      <VCardText>Дополнительные условия</VCardText>
      <VRadioGroup inline label="Банковские условия" :rules="[validators.requiredRule]">
          <VRadio label="Нет" :true-value="() => { currentItem.accreditive = false; currentItem.bankGuarantee = false }" />
          <VRadio label="Банковская гарантия" :false-value="() => { currentItem.bankGuarantee = false }" :true-value="() => { currentItem.bankGuarantee = true }" />
          <VRadio label="Аккредитив" :false-value="() => { currentItem.accreditive = false }" :true-value="() => { currentItem.accreditive = true }" />
      </VRadioGroup>
      <VRadioGroup inline label="Таможенное условие 1" v-model="currentItem.customDuty" :rules="[validators.requiredRule]">
          <VRadio label="Нет" value="false" />
          <VRadio label="Таможенная пошлина" value="true" />
      </VRadioGroup>
      <VRadioGroup inline label="Таможенное условие 2" v-model="currentItem.customFee" :rules="[validators.requiredRule]">
          <VRadio label="Нет" value="false" />
          <VRadio label="Таможенный сбор" value="true" />
      </VRadioGroup>
      <VDivider />
      <VCardText>Критерии надежности</VCardText>
      <VRadioGroup inline label="Были нарушения сроков поставки" v-model="currentItem.missingDeadlines" :rules="[validators.requiredRule]">
          <VRadio label="Да" value="true" />
          <VRadio label="Нет" value="false" />
      </VRadioGroup>
      <VRadioGroup inline label="Были претензии к качеству товара/услуги" v-model="currentItem.poorQuality" :rules="[validators.requiredRule]">
          <VRadio label="Да" value="true" />
          <VRadio label="Нет" value="false" />
      </VRadioGroup>
      <VRadioGroup inline label="Были нарушения внутренних норм" v-model="currentItem.normsViolated" :rules="[validators.requiredRule]">
          <VRadio label="Да" value="true" />
          <VRadio label="Нет" value="false" />
      </VRadioGroup>
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

const bankTerms = () => {

}

const lengthRule50 : ILengthRule = { max: 50 }

const currentItem = ref({
  proposalId: 0,
  agentId: 0,
  userId: 0,
  tenderId: 0,
  countPos: 0,
  positionPrice: 0,
  deliveryCost: 0,
  deliveryTime: 0,

  prepaidExpense1: 0,
  prepaidExpense2: 0,
  prepaidExpense3: 0,

  periodOfExecution1: 0,
  periodOfExecution2: 0,
  periodOfExecution3: 0,

  postPaymant1: 0,
  postPaymant2: 0,
  postPaymant3: 0,

  postPaymantPeriod1: 0,
  postPaymantPeriod2: 0,
  postPaymantPeriod3: 0,

  accreditive: false,
  bankGuarantee: false,

  customDuty: false,
  customFee: false,

  missingDeadlines: false,
  poorQuality: false,
  normsViolated: false,

  experienceCooperation: false,
  experienceMarket: false,
  fines: false,
  intermediary: false,
  productionAndInventory: false,
  modernEquipment: false,
  georgraphy: false,
  concessions: false,
  complaints: false,
})

watch(
  () => props.editedItem,
  (newVal) => {
    currentItem.value.proposalId = newVal?.proposalId
    currentItem.value.agentId = newVal?.agent.agentId
    currentItem.value.userId = newVal?.user.userId
    currentItem.value.tenderId = newVal?.tender.tenderId
    currentItem.value.countPos = newVal?.countPos
    currentItem.value.positionPrice = newVal?.positionPrice
    currentItem.value.deliveryCost = newVal?.deliveryCost
    currentItem.value.deliveryTime = newVal?.deliveryTime
    currentItem.value.prepaidExpense1 = newVal?.prepaidExpense1
    currentItem.value.prepaidExpense2 = newVal?.prepaidExpense2
    currentItem.value.prepaidExpense3 = newVal?.prepaidExpense3
    currentItem.value.periodOfExecution1 = newVal?.periodOfExecution1
    currentItem.value.periodOfExecution2 = newVal?.periodOfExecution2
    currentItem.value.periodOfExecution3 = newVal?.periodOfExecution3
    currentItem.value.postPaymant1 = newVal?.postPaymant1
    currentItem.value.postPaymant2 = newVal?.postPaymant2
    currentItem.value.postPaymant3 = newVal?.postPaymant3
    currentItem.value.postPaymantPeriod1 = newVal?.postPaymantPeriod1
    currentItem.value.postPaymantPeriod2 = newVal?.postPaymantPeriod2
    currentItem.value.postPaymantPeriod3 = newVal?.postPaymantPeriod3
    currentItem.value.accreditive = newVal?.accreditive
    currentItem.value.bankGuarantee = newVal?.bankGuarantee
    currentItem.value.customDuty = newVal?.customDuty
    currentItem.value.customFee = newVal?.customFee
    currentItem.value.missingDeadlines = newVal?.missingDeadlines
    currentItem.value.poorQuality = newVal?.poorQuality
    // currentItem.value.normsViolated = newVal?.normsViolated
    // currentItem.value.experienceCooperation = newVal?.experienceCooperation
    // currentItem.value.experienceMarket = newVal?.experienceMarket
    // currentItem.value.fines = newVal?.fines
    // currentItem.value.intermediary = newVal?.intermediary
    // currentItem.value.productionAndInventory = newVal?.productionAndInventory
    // currentItem.value.modernEquipment = newVal?.modernEquipment
    // currentItem.value.georgraphy = newVal?.georgraphy
    // currentItem.value.concessions = newVal?.concessions
    // currentItem.value.complaints = newVal?.complaints
})

const save = () => {
  const item = {
    proposalId: currentItem.value.proposalId,
    agent: {
      agentId: currentItem.value.agentId,
    },
    user: {
      userId: 0,
    },
    tender: {
      tenderId: currentItem.value.tenderId
    },
    countPos: currentItem.value.countPos,
    positionPrice: currentItem.value.positionPrice,
    deliveryCost: currentItem.value.deliveryCost,
    deliveryTime: currentItem.value.deliveryTime,
    prepaidExpense1: currentItem.value.prepaidExpense1,
    prepaidExpense2: currentItem.value.prepaidExpense2,
    prepaidExpense3: currentItem.value.prepaidExpense3,
    periodOfExecution1: currentItem.value.periodOfExecution1,
    periodOfExecution2: currentItem.value.periodOfExecution2,
    periodOfExecution3: currentItem.value.periodOfExecution3,
    postPaymant1: currentItem.value.postPaymant1,
    postPaymant2: currentItem.value.postPaymant2,
    postPaymant3: currentItem.value.postPaymant3,
    postPaymantPeriod1: currentItem.value.postPaymantPeriod1,
    postPaymantPeriod2: currentItem.value.postPaymantPeriod2,
    postPaymantPeriod3: currentItem.value.postPaymantPeriod3,
    accreditive: currentItem.value.accreditive,
    bankGuarantee: currentItem.value.bankGuarantee,
    customDuty: currentItem.value.customDuty,
    customFee: currentItem.value.customFee,
    missingDeadlines: currentItem.value.missingDeadlines,
    poorQuality: currentItem.value.poorQuality,
    // normsViolated: currentItem.value.normsViolated,
    // experienceCooperation: currentItem.value.experienceCooperation,
    // experienceMarket: currentItem.value.experienceMarket,
    // fines: currentItem.value.fines,
    // intermediary: currentItem.value.intermediary,
    // productionAndInventory: currentItem.value.productionAndInventory,
    // modernEquipment: currentItem.value.modernEquipment,
    // georgraphy: currentItem.value.georgraphy,
    // concessions: currentItem.value.concessions,
    // complaints: currentItem.value.complaints,
  }
  
  const $helpers = helpers()
  const request = $helpers.BuildQuery(props.isNew ? HttpQueryType.post : HttpQueryType.put, item)
  if (props.isNew) {
    fetchData(props.apiAddress!, request)
      .then(() => {
        isActiveForm.value = false
      })
  } else {
    fetchData(`${props.apiAddress!}/${item.proposalId}`, item)
      .then(() => {
        isActiveForm.value = false
      })
  }
}

const close = () => {
  emit('update:isActive', false)
}
</script>

