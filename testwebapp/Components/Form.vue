<template v-slot:default="{ isActive }">
    <v-card>
        <v-toolbar title=title></v-toolbar>

        <v-card-text class="text-h2 pa-12">
            
            <v-text-field
                label="Контрагент"
                prepend-icon="mdi-briefcase-account"
                variant="outlined"
                v-model="contrAgent.Dict_Contragent.Counterparty"
            />
            <v-divider />
            <v-card-text>Объем закупки</v-card-text>
            <v-text-field
                label="Количество товара(услуг), ед"
                prepend-icon="mdi-briefcase-account"
                variant="outlined"
                v-model="contrAgent.Var_Contragent_Of_Tenders.CountPos"
            />
            <v-text-field
                label="Стоимость 1 ед товара(услуги)"
                prepend-icon="mdi-briefcase-account"
                variant="outlined"
                v-model="contrAgent.Var_Contragent_Of_Tenders.PositionPrice"
            />
            <v-text-field
                label="Стоимость доставки, руб."
                prepend-icon="mdi-cash"
                variant="outlined"
                v-model="contrAgent.Var_Contragent_Of_Tenders.DeliveryCost"
            />
            <v-text-field
                label="Сроки поставки, дн"
                prepend-icon="mdi-timer-settings-outline"
                variant="outlined"
                v-model="contrAgent.Var_Contragent_Of_Tenders.DeliveryCount"
            >
                <v-tooltip 
                    activator="parent"
                    location="top"
                    text="Количество дней между датой заключения договора(или первого аванса) и даты поставки товара. Шаг рассчета 5 дней" />
            </v-text-field>
            <v-divider />
            <v-card-text>Условия оплаты</v-card-text>
            
            <v-text-field
                label="Аванс 1"
                prepend-icon="mdi-cash"
                variant="outlined"
                v-model="contrAgent.Economic_effect_Var.PrepaidExpense1"
            />
            
            <v-text-field
                label="Аванс 2"
                prepend-icon="mdi-cash"
                variant="outlined"
                v-model="contrAgent.Economic_effect_Var.PrepaidExpense2"
            />
            <v-text-field
                label="Аванс 3"
                prepend-icon="mdi-cash"
                variant="outlined"
                v-model="contrAgent.Economic_effect_Var.PrepaidExpense3"
            />
            
            <v-text-field
                label="Срок аванса 1, дн"
                prepend-icon="mdi-timer-settings-outline"
                variant="outlined"
                v-model="contrAgent.Economic_effect_Var.PeriodOfExecution1"
            >
                <v-tooltip text="Количество дней между датой аванса и датой поступления товара на склад. Шаг рассчета 5 дней" />
            </v-text-field>
            <v-text-field
                label="Срок аванса 2, дн"
                prepend-icon="mdi-timer-settings-outline"
                variant="outlined"
                v-model="contrAgent.Economic_effect_Var.PeriodOfExecution2"
            />
            <v-text-field
                label="Срок аванса 3, дн"
                prepend-icon="mdi-timer-settings-outline"
                variant="outlined"
                v-model="contrAgent.Economic_effect_Var.PeriodOfExecution3"
            />

            <v-text-field
                label="Постоплата 1, %"
                prepend-icon="mdi-cash-100"
                variant="outlined"
                v-model="contrAgent.Economic_effect_Var.PostPaymant1"
            />
            <v-text-field
                label="Постоплата 2, %"
                prepend-icon="mdi-cash-100"
                variant="outlined"
                v-model="contrAgent.Economic_effect_Var.PostPaymant2"
            />
            <v-text-field
                label="Постоплата 3, %"
                prepend-icon="mdi-cash-100"
                variant="outlined"
                v-model="contrAgent.Economic_effect_Var.PostPaymant3"
            />
            <v-text-field
                label="Срок постоплаты 1, дн"
                prepend-icon="mdi-timer-settings-outline"
                variant="outlined"
                v-model="contrAgent.Economic_effect_Var.PostPaymantPeriod1"
            >
                <v-tooltip text="Количество дней между датой поставки товаров и планируемой датой постоплаты. Шаг рассчета 5 дней" />
            </v-text-field>
            <v-text-field
                label="Срок постоплаты 2, дн"
                prepend-icon="mdi-timer-settings-outline"
                variant="outlined"
                v-model="contrAgent.Economic_effect_Var.PostPaymantPeriod2"
            />
            <v-text-field
                label="Срок постоплаты 3, дн"
                prepend-icon="mdi-timer-settings-outline"
                variant="outlined"
                v-model="contrAgent.Economic_effect_Var.PostPaymantPeriod3"
            />
            <v-divider />
            <v-card-text>Дополнительные условия</v-card-text>
            <v-radio-group inline label="Банковские условия" v-model="bankRequirement">
                <v-radio label="Нет" value=""></v-radio>
                <v-radio label="Банковская гарантия" value="isBankGuarantee"></v-radio>
                <v-radio label="Аккредитив" value="isAccreditive"></v-radio>
            </v-radio-group>
            <v-radio-group inline label="Таможенное условие 1" v-model="customDuty">
                <v-radio label="Нет" value="false"></v-radio>
                <v-radio label="Таможенная пошлина" value="true"></v-radio>
            </v-radio-group>
            <v-radio-group inline label="Таможенное условие 2" v-model="customFee">
                <v-radio label="Нет" value="false"></v-radio>
                <v-radio label="Таможенный сбор" value="true"></v-radio>
            </v-radio-group>
            <v-divider />
            <v-card-text>Критерии надежности</v-card-text>
            <v-radio-group inline label="Были нарушения сроков поставки" v-model="missingDeadlines">
                <v-radio label="Да" value="true"></v-radio>
                <v-radio label="Нет" value="false"></v-radio>
            </v-radio-group>
            <v-radio-group inline label="Были претензии к качеству товара/услуги" v-model="poorQuality" >
                <v-radio label="Да" value="true"></v-radio>
                <v-radio label="Нет" value="false"></v-radio>
            </v-radio-group>
            <v-radio-group inline label="Были нарушения внутренних норм" v-model="normsViolated" >
                <v-radio label="Да" value="true"></v-radio>
                <v-radio label="Нет" value="false"></v-radio>
            </v-radio-group>
        </v-card-text>
        <v-divider />
        <v-card-actions class="justify-сутеук">
            <v-btn
                text="Сохранить"
                @click="SaveForm()"
            ></v-btn>
            <v-btn
                text="Close"
                @click="$emit('closeForm', false)"
            ></v-btn>
        </v-card-actions>
    </v-card>
</template>

<script lang="ts" setup>
defineProps({
    title: String,
})
</script>

<script lang="ts">
export default
{
    data()
    {
        return {
            contrAgent:
            {
                Dict_Contragent:
                {
                    Counterparty: '',
                },
                Var_Contragent_Of_Tenders:
                {
                    CountPos: 0,
                    PositionPrice: 0,
                    DeliveryCost: 0,
                    DeliveryCount: 0,
                },
                Economic_effect_Var:
                {
                    PrepaidExpense1: 0,
                    PrepaidExpense2: 0,
                    PrepaidExpense3: 0,
                    PeriodOfExecution1: 0,
                    PeriodOfExecution2: 0,
                    PeriodOfExecution3: 0,
                    PostPaymant1: 0,
                    PostPaymant2: 0,
                    PostPaymant3: 0,
                    PostPaymantPeriod1: 0,
                    PostPaymantPeriod2: 0,
                    PostPaymantPeriod3: 0,
                    Accreditive: false,
                    BankGuarantee: false,
                    CustomDuty: false,
                    CustomFee: false,
                    MissingDeadlines: false,
                    PoorQuality: false,
                    NormsViolated: false,
                }
            },
            bankRequirement:'',
            customDuty:'',
            customFee:'',
            missingDeadlines:'',
            poorQuality:'',
            normsViolated:'',
        }
    },
    created()
    {
        // this.contrAgent = {
        //     Counterparty: '',
        //     CountPos: 0,
        //     PositionPrice: 0,
        //     DeliveryCost: 0,
        //     DeliveryCount: 0,
        //     PrepaidExpense1: 0,
        //     PrepaidExpense2: 0,
        //     PrepaidExpense3: 0,
        //     PeriodOfExecution1: 0,
        //     PeriodOfExecution2: 0,
        //     PeriodOfExecution3: 0,
        //     PostPaymant1: 0,
        //     PostPaymant2: 0,
        //     PostPaymant3: 0,
        //     PostPaymantPeriod1: 0,
        //     PostPaymantPeriod2: 0,
        //     PostPaymantPeriod3: 0,
        //     Accreditive: false,
        //     BankGuarantee: false,
        //     CustomDuty: false,
        //     CustomFee: false,
        // }
    },
    methods:
    {
        SaveForm()
        {
            switch (this.bankRequirement)
            {
                case '':
                    this.contrAgent.Economic_effect_Var.Accreditive=false;
                    this.contrAgent.Economic_effect_Var.BankGuarantee=false;
                    break;
                case 'isAccreditive':
                    this.contrAgent.Economic_effect_Var.Accreditive=true;
                    this.contrAgent.Economic_effect_Var.BankGuarantee=false;
                    break;
                case 'isBankGuarantee':
                    this.contrAgent.Economic_effect_Var.Accreditive=false;
                    this.contrAgent.Economic_effect_Var.BankGuarantee=true;
                    break;
            }

            switch(this.customDuty)
            {
                case 'true':
                    this.contrAgent.Economic_effect_Var.CustomDuty=true;
                    break;
                case '':
                case 'false':
                    this.contrAgent.Economic_effect_Var.CustomDuty=false;
                    break;
            }

            switch(this.customFee)
            {
                case 'true':
                    this.contrAgent.Economic_effect_Var.CustomFee=true;
                    break;
                case '':
                case 'false':
                    this.contrAgent.Economic_effect_Var.CustomFee=false;
                    break;
            }

            switch(this.missingDeadlines)
            {
                case 'true':
                    this.contrAgent.Economic_effect_Var.MissingDeadlines=true;
                    break;
                case '':
                case 'false':
                    this.contrAgent.Economic_effect_Var.MissingDeadlines=false;
                    break;
            }

            switch(this.poorQuality)
            {
                case 'true':
                    this.contrAgent.Economic_effect_Var.PoorQuality=true;
                    break;
                case '':
                case 'false':
                    this.contrAgent.Economic_effect_Var.PoorQuality=false;
                    break;
            }

            switch(this.normsViolated)
            {
                case 'true':
                    this.contrAgent.Economic_effect_Var.NormsViolated=true;
                    break;
                case '':
                case 'false':
                    this.contrAgent.Economic_effect_Var.NormsViolated=false;
                    break;
            }

            this.contrAgent.Var_Contragent_Of_Tenders.CountPos=parseFloat(this.contrAgent.Var_Contragent_Of_Tenders.CountPos.toString());
            this.contrAgent.Var_Contragent_Of_Tenders.PositionPrice=parseFloat(this.contrAgent.Var_Contragent_Of_Tenders.PositionPrice.toString());

            this.contrAgent.Var_Contragent_Of_Tenders.DeliveryCost=parseFloat(this.contrAgent.Var_Contragent_Of_Tenders.DeliveryCost.toString());
            this.contrAgent.Var_Contragent_Of_Tenders.DeliveryCount=parseFloat(this.contrAgent.Var_Contragent_Of_Tenders.DeliveryCost.toString());
            this.contrAgent.Economic_effect_Var.PrepaidExpense1=parseFloat(this.contrAgent.Economic_effect_Var.PrepaidExpense1.toString());
            this.contrAgent.Economic_effect_Var.PrepaidExpense2=parseFloat(this.contrAgent.Economic_effect_Var.PrepaidExpense2.toString());
            this.contrAgent.Economic_effect_Var.PrepaidExpense3=parseFloat(this.contrAgent.Economic_effect_Var.PrepaidExpense3.toString());
            this.contrAgent.Economic_effect_Var.PeriodOfExecution1=parseFloat(this.contrAgent.Economic_effect_Var.PeriodOfExecution1.toString());
            this.contrAgent.Economic_effect_Var.PeriodOfExecution2=parseFloat(this.contrAgent.Economic_effect_Var.PeriodOfExecution2.toString());
            this.contrAgent.Economic_effect_Var.PeriodOfExecution3=parseFloat(this.contrAgent.Economic_effect_Var.PeriodOfExecution3.toString());
            this.contrAgent.Economic_effect_Var.PostPaymant1=parseFloat(this.contrAgent.Economic_effect_Var.PostPaymant1.toString());
            this.contrAgent.Economic_effect_Var.PostPaymant2=parseFloat(this.contrAgent.Economic_effect_Var.PostPaymant2.toString());
            this.contrAgent.Economic_effect_Var.PostPaymant3=parseFloat(this.contrAgent.Economic_effect_Var.PostPaymant3.toString());
            this.contrAgent.Economic_effect_Var.PostPaymantPeriod1=parseFloat(this.contrAgent.Economic_effect_Var.PostPaymantPeriod1.toString());
            this.contrAgent.Economic_effect_Var.PostPaymantPeriod2=parseFloat(this.contrAgent.Economic_effect_Var.PostPaymantPeriod2.toString());
            this.contrAgent.Economic_effect_Var.PostPaymantPeriod3=parseFloat(this.contrAgent.Economic_effect_Var.PostPaymantPeriod3.toString());

            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                //mode: 'no-cors',
                body: JSON.stringify(this.contrAgent)
            }

            fetch('http://localhost:5037/api/contragents', requestOptions)
        }
    }
}
</script>