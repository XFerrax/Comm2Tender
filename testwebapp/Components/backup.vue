<template>
    <v-spacer />
    <template v-for="item in currentItems">
      <v-col md = "2">
        <v-card>
            <v-text-field label="Контрагент" v-model="item.counterparty" />
            <v-text-field label="Стоимость заказа" v-model="item.cZakazValue" />
            <v-text-field label="Экономический эффект" v-model="item.economicEffectValue" />
            <v-text-field label="Оценка надежности" v-model="item.reliabilityAssessmentValue" />
            <v-text-field label="Интегральная оценка" v-model="item.integratedAssessmentsValue" />
            <div class="subheading font-weight-light text-grey pa-5">Оценка</div>
            <v-sparkline :max="maxHist" :min="minHist" :item-value="item.integratedAssessmentsValue.toString()" />
            <div class="subheading font-weight-light text-grey pa-5">Доп. коэффициенты</div>
            <v-checkbox label="Опыт работы с контр агентом" />
            <v-checkbox label="Опыт работы на рынке" />
            <v-checkbox label="отсутсвие штрафов и судебных издержек" />
            <v-checkbox label="Опыт работы с контр агентом" />
            <v-radio-group inline >
                <v-radio label="Производитель" />
                <v-radio label="Посредник" />
            </v-radio-group>
            <v-checkbox label="Производство и складские запасы" />
            <v-checkbox label="Наличие современного оборудования" />
            <v-checkbox label="Географическая близость к заказчику" />
            <v-checkbox label="Лояльность в рамках тендера" />
            <v-checkbox label="Отсутвие рекламаций" />

        </v-card>
      </v-col>
    </template>
    <v-btn @click="load()" text="load"/>
</template>

<script lang="ts" setup>
  defineProps({
  })
</script>

<script lang="ts">
  export default {
    data () 
    {
      return {
        currentItems:[{
          counterparty: '',
          cZakazValue: 0,
          economicEffectValue: 0,
          reliabilityAssessmentValue: 0,
          integratedAssessmentsValue: 0,
        }],
        minHist:0,
        maxHist:0,
      }
    },
    created: () =>
    {
      
    },
    mounted: () =>
    {
      //load()
    },
    methods:
    {
      async load()
      {
        const requestOptions = {
                method: 'get',
                headers: { 'Content-Type': 'application/json' },
            }

            var resp = await fetch('http://localhost:5037/api/contragents', requestOptions)
            .then(response => response.json())
            .then(result =>
              {
                this.currentItems = result
                Math.max(...this.currentItems.map(a=>a.integratedAssessmentsValue))
                Math.min(...this.currentItems.map(a=>a.integratedAssessmentsValue))
              })
      }

    }
  }

</script>

<style>

</style>