using Comm2Tender.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Comm2Tender.Dtos
{
    public class ContractorDto
    {
        [JsonPropertyName("Dict_Contragent")]
        public DictContragent DictContragent { get; set; }
        
        [JsonPropertyName("Var_Contragent_Of_Tenders")]
        public VarContragentOfTender VarContragentOfTender { get; set; }

        [JsonPropertyName("Economic_effect_Var")]
        public EconomicEffectVar EconomicEffectVar { get; set; }
    }
}

/*
 Dict_Contragent:
Counterparty: String,

Var_Contragent_Of_Tenders:
                CountPos: Number,//(int)
                PositionPrice: Number,//(float)
                DeliveryCost: Number,//(float)
                DeliveryCount:Number,//(int)

Economic_effect_Var:l
                PrepaidExpense1:Number,//(float)
                PrepaidExpense2:Number,//(float)
                PrepaidExpense3:Number,//(float)
                PeriodOfExecution1:Number,//(int)
                PeriodOfExecution2:Number,//(int)
                PeriodOfExecution3:Number,//(int)
                PostPaymant1:Number,//(int)
                PostPaymant2:Number,//(int)
                PostPaymant3:Number,//(int)
                PostPaymantPeriod1:Number,//(int)
                PostPaymantPeriod2:Number,//(int)
                PostPaymantPeriod3:Number,//(int)
                Accreditive:Boolean,
                BankGuarantee:Boolean,
                CustomDuty:Boolean,
                CustomFee:Boolean,


{
    "Dict_Contragent": {
        "Counterparty": "String"
    },
    "Var_Contragent_Of_Tenders": {
        "CountPos": 0,
        "PositionPrice": 0.0,
        "DeliveryCost": 0.0,
        "DeliveryCount": 0
    },
    "Economic_effect_Var": {
        "PrepaidExpense1": 0.0,
        "PrepaidExpense2": 0.0,
        "PrepaidExpense3": 0.0,
        "PeriodOfExecution1": 0,
        "PeriodOfExecution2": 0,
        "PeriodOfExecution3": 0,
        "PostPaymant1": 0,
        "PostPaymant2": 0,
        "PostPaymant3": 0,
        "PostPaymantPeriod1": 0,
        "PostPaymantPeriod2": 0,
        "PostPaymantPeriod3": 0,
        "Accreditive": false,
        "BankGuarantee": false,
        "CustomDuty": false,
        "CustomFee": false
    }
}
 */