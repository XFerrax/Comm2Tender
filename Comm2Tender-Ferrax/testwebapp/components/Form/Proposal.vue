<template>
  <Form v-model:isActive="props.isActive" v-bind:save-func="save" :title="props.title" :title-suffix="props.titleSuffix" :close-func="close" :is-new="props.isNew">
    <template #fields>
      <Select v-model="currentItem.agentId" :visible="true" :rules="[validators.requiredRule]" api-address="agent" item-title="name" label="Контрагент" />
      <Select v-model="currentItem.tenderId" :visible="true" :rules="[validators.requiredRule]" api-address="tender" item-title="number" label="Тендер" />
      <VDivider />
      <VCardText>Объем закупки</VCardText>
      <VTextField
        label="Количество товара(услуг), ед"
        prepend-icon="mdi-briefcase-account"
        variant="outlined"
        :rules="[validators.requiredRule, validators.lengthRule(currentItem.countPos.toString(), myLengthRule(0, 9))]" 
        v-model="currentItem.countPos">
        <template #label><FormLabel label="Количество товара(услуг), ед" required /></template>
      </VTextField>
      <VTextField
        label="Стоимость 1 ед товара(услуги)"
        prepend-icon="mdi-briefcase-account"
        variant="outlined"
        :rules="[validators.requiredRule, validators.lengthRule(currentItem.positionPrice.toString(), myLengthRule(0, 9))]"
        v-model="currentItem.positionPrice">
        <template #label><FormLabel label="Стоимость 1 ед товара(услуги)" required /></template>
      </VTextField>
      <VTextField
        label="Стоимость доставки, руб."
        prepend-icon="mdi-cash"
        variant="outlined"
        :rules="[validators.requiredRule, validators.lengthRule(currentItem.deliveryCost.toString(), myLengthRule(0, 9))]"
        v-model="currentItem.deliveryCost">
          <template #label><FormLabel label="Стоимость доставки, руб." required /></template></VTextField>
      <VTextField
        label="Сроки поставки, дн"
        prepend-icon="mdi-timer-settings-outline"
        variant="outlined"
        :rules="[validators.requiredRule, validators.lengthRule(currentItem.deliveryTime.toString(), myLengthRule(0, 9))]"
        v-model="currentItem.deliveryTime"
      >
        <template #label><FormLabel label="Сроки поставки, дн" required /></template>
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
        :rules="[
          validators.requiredRule, 
          validators.lengthRule(currentItem.prepaidExpense1.toString(), myLengthRule(0, 9)),
          validators.summaryControl([
            currentItem.prepaidExpense1,
            currentItem.prepaidExpense2,
            currentItem.prepaidExpense3,
            currentItem.postPaymant1,
            currentItem.postPaymant2,
            currentItem.postPaymant3,
          ], 100)
        ]"
        v-model="currentItem.prepaidExpense1">
          <template #label><FormLabel label="Аванс 1" required /></template></VTextField>
      
      <VTextField
        label="Аванс 2"
        prepend-icon="mdi-cash"
        variant="outlined"
        :rules="[
          validators.requiredRule, 
          validators.lengthRule(currentItem.prepaidExpense2.toString(), myLengthRule(0, 9)),
          validators.summaryControl([
            currentItem.prepaidExpense1,
            currentItem.prepaidExpense2,
            currentItem.prepaidExpense3,
            currentItem.postPaymant1,
            currentItem.postPaymant2,
            currentItem.postPaymant3,
          ], 100)
        ]"
        v-model="currentItem.prepaidExpense2">
          <template #label><FormLabel label="Аванс 2" required /></template>
      </VTextField> 
      <VTextField
        label="Аванс 3"
        prepend-icon="mdi-cash"
        variant="outlined"
        :rules="[
          validators.requiredRule, 
          validators.lengthRule(currentItem.prepaidExpense3.toString(), myLengthRule(0, 9)),
          validators.summaryControl([
            currentItem.prepaidExpense1,
            currentItem.prepaidExpense2,
            currentItem.prepaidExpense3,
            currentItem.postPaymant1,
            currentItem.postPaymant2,
            currentItem.postPaymant3,
          ], 100)
        ]"
        v-model="currentItem.prepaidExpense3">
          <template #label><FormLabel label="Аванс 3" required /></template>
      </VTextField>
      
      <VTextField
        label="Срок аванса 1, дн"
        prepend-icon="mdi-timer-settings-outline"
        variant="outlined"
        :rules="[
          validators.requiredRule, 
          validators.lengthRule(currentItem.periodOfExecution1.toString(), myLengthRule(0, 9)), 
          validators.multiplicity(currentItem.periodOfExecution1, 5)
        ]"
        v-model="currentItem.periodOfExecution1"
      >
        <template #label><FormLabel label="Срок аванса 1, дн" required /></template>
          <VTooltip text="Количество дней между датой аванса и датой поступления товара на склад. Шаг рассчета 5 дней" />
      </VTextField>
      <VTextField
        label="Срок аванса 2, дн"
        prepend-icon="mdi-timer-settings-outline"
        variant="outlined"
        :rules="[
          validators.requiredRule, 
          validators.lengthRule(currentItem.periodOfExecution2.toString(), myLengthRule(0, 9)), 
          validators.multiplicity(currentItem.periodOfExecution2, 5)
        ]"
        v-model="currentItem.periodOfExecution2">
          <template #label><FormLabel label="Срок аванса 2, дн" required /></template>  
      </VTextField>
      <VTextField
        label="Срок аванса 3, дн"
        prepend-icon="mdi-timer-settings-outline"
        variant="outlined"
        :rules="[
          validators.requiredRule, 
          validators.lengthRule(currentItem.periodOfExecution3.toString(), myLengthRule(0, 9)), 
          validators.multiplicity(currentItem.periodOfExecution3, 5)
        ]"
        v-model="currentItem.periodOfExecution3">
          <template #label><FormLabel label="Срок аванса 3, дн" required /></template>
        </VTextField>

      <VTextField
        label="Постоплата 1, %"
        prepend-icon="mdi-cash-100"
        variant="outlined"
        :rules="[
          validators.requiredRule, 
          validators.lengthRule(currentItem.postPaymant1.toString(), myLengthRule(0, 9)),
          validators.summaryControl([
            currentItem.prepaidExpense1,
            currentItem.prepaidExpense2,
            currentItem.prepaidExpense3,
            currentItem.postPaymant1,
            currentItem.postPaymant2,
            currentItem.postPaymant3,
          ], 100)
        ]"
        v-model="currentItem.postPaymant1">
        <template #label><FormLabel label="Постоплата 1, %" required /></template>
      </VTextField>
      <VTextField
        label="Постоплата 2, %"
        prepend-icon="mdi-cash-100"
        variant="outlined"
        :rules="[
          validators.requiredRule, 
          validators.lengthRule(currentItem.postPaymant2.toString(), myLengthRule(0, 9)),
          validators.summaryControl([
            currentItem.prepaidExpense1,
            currentItem.prepaidExpense2,
            currentItem.prepaidExpense3,
            currentItem.postPaymant1,
            currentItem.postPaymant2,
            currentItem.postPaymant3,
          ], 100)
        ]"
        v-model="currentItem.postPaymant2">
          <template #label><FormLabel label="Постоплата 2, %" required /></template>
        </VTextField>
      <VTextField
        label="Постоплата 3, %"
        prepend-icon="mdi-cash-100"
        variant="outlined"
        :rules="[
          validators.requiredRule, 
          validators.lengthRule(currentItem.postPaymant3.toString(), myLengthRule(0, 9)),
          validators.summaryControl([
            currentItem.prepaidExpense1,
            currentItem.prepaidExpense2,
            currentItem.prepaidExpense3,
            currentItem.postPaymant1,
            currentItem.postPaymant2,
            currentItem.postPaymant3,
          ], 100)
        ]"
        v-model="currentItem.postPaymant3">
          <template #label><FormLabel label="Постоплата 3, %" required /></template>
        </VTextField>
      <VTextField
        label="Срок постоплаты 1, дн"
        prepend-icon="mdi-timer-settings-outline"
        variant="outlined"
        :rules="[validators.requiredRule, validators.lengthRule(currentItem.postPaymantPeriod1.toString(), myLengthRule(0, 9))]"
        v-model="currentItem.postPaymantPeriod1">
          <template #label><FormLabel label="Срок постоплаты 1, дн" required /></template>
          <VTooltip text="Количество дней между датой поставки товаров и планируемой датой постоплаты. Шаг рассчета 5 дней" />
      </VTextField>
      <VTextField
        label="Срок постоплаты 2, дн"
        prepend-icon="mdi-timer-settings-outline"
        variant="outlined"
        :rules="[validators.requiredRule, validators.lengthRule(currentItem.postPaymantPeriod2.toString(), myLengthRule(0, 9))]"
        v-model="currentItem.postPaymantPeriod2">
          <template #label><FormLabel label="Срок постоплаты 2, дн" required /></template>
        </VTextField>
      <VTextField
        label="Срок постоплаты 3, дн"
        prepend-icon="mdi-timer-settings-outline"
        variant="outlined"
        :rules="[validators.requiredRule, validators.lengthRule(currentItem.postPaymantPeriod3.toString(), myLengthRule(0, 9))]"
        v-model="currentItem.postPaymantPeriod3">
          <template #label><FormLabel label="Срок постоплаты 3, дн" required /></template>
        </VTextField>
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
import { requiredRule, lengthRule } from '~/utils/validators'
import helpers, { HttpQueryType } from '~/utils/helpers'
import type { ILengthRule } from '~/utils/helpers'
import { fetchData } from '~/plugins/api'
import mixinPropsForm from '~/composables/mixinPropsForm'

const props = defineProps(mixinPropsForm)
const emit = defineEmits(['update:isActive'])

const validators = {
  requiredRule,
  lengthRule,
  multiplicity: (val1: number, controlMultiplicity: number) => {
    return val1 % controlMultiplicity == 0 ? true : `Значение должно быть кратным ${controlMultiplicity}`
  },
  summaryControl: (values: number[], controlSummary: number) => {
    return controlSummary == values.reduce((accum, current) => accum += current, 0) ? true : `В сумме должно быть ${controlSummary}`
  },
}

const isActiveForm = ref(props.isActive)

const myLengthRule = (min?: number, max?: number) : ILengthRule => {
  const ret = {}
  if (min) { ret: { min: min } }
  if (max) { ret: { max: max } }
  return ret 
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
    ProposalId: currentItem.value.proposalId,
    Agent: {
      AgentId: currentItem.value.agentId,
    },
    User: {
      UserId: 0,
    },
    Tender: {
      TenderId: currentItem.value.tenderId
    },
    CountPos: currentItem.value.countPos,
    PositionPrice: currentItem.value.positionPrice,
    DeliveryCost: currentItem.value.deliveryCost,
    DeliveryTime: currentItem.value.deliveryTime,
    PrepaidExpense1: currentItem.value.prepaidExpense1,
    PrepaidExpense2: currentItem.value.prepaidExpense2,
    PrepaidExpense3: currentItem.value.prepaidExpense3,
    PeriodOfExecution1: currentItem.value.periodOfExecution1,
    PeriodOfExecution2: currentItem.value.periodOfExecution2,
    PeriodOfExecution3: currentItem.value.periodOfExecution3,
    PostPaymant1: currentItem.value.postPaymant1,
    PostPaymant2: currentItem.value.postPaymant2,
    PostPaymant3: currentItem.value.postPaymant3,
    PostPaymantPeriod1: currentItem.value.postPaymantPeriod1,
    PostPaymantPeriod2: currentItem.value.postPaymantPeriod2,
    PostPaymantPeriod3: currentItem.value.postPaymantPeriod3,
    Accreditive: currentItem.value.accreditive,
    BankGuarantee: currentItem.value.bankGuarantee,
    CustomDuty: currentItem.value.customDuty,
    CustomFee: currentItem.value.customFee,
    MissingDeadlines: currentItem.value.missingDeadlines,
    PoorQuality: currentItem.value.poorQuality,
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
    fetchData(`${props.apiAddress!}/${item.ProposalId}`, item)
      .then(() => {
        isActiveForm.value = false
      })
  }
}

const close = () => {
  emit('update:isActive', false)
}
</script>

