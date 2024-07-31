namespace Comm2TenderBlazor.Models.ViewModels
{
    using System.Text.Json.Serialization;

    public class ProposalViewModel
    {
        [JsonPropertyName("proposalId")]
        public int ProposalId { get; set; } // int

        [JsonPropertyName("agentId")]
        public int AgentId { get; set; } // int

        [JsonPropertyName("userId")]
        public int UserId { get; set; } // int

        [JsonPropertyName("tenderId")]
        public int TenderId { get; set; } // int

        [JsonPropertyName("countPos")]
        public int CountPos { get; set; } // int

        [JsonPropertyName("positionPrice")]
        public decimal PositionPrice { get; set; } // decimal(8, 3)

        [JsonPropertyName("deliveryCost")]
        public decimal DeliveryCost { get; set; } // decimal(8, 3)

        [JsonPropertyName("deliveryTime")]
        public int DeliveryTime { get; set; } // int

        [JsonPropertyName("prepaidExpense1")]
        public decimal PrepaidExpense1 { get; set; } // decimal(8, 3)

        [JsonPropertyName("prepaidExpense2")]
        public decimal PrepaidExpense2 { get; set; } // decimal(8, 3)

        [JsonPropertyName("prepaidExpense3")]
        public decimal PrepaidExpense3 { get; set; } // decimal(8, 3)

        [JsonPropertyName("periodOfExecution1")]
        public int PeriodOfExecution1 { get; set; } // int

        [JsonPropertyName("periodOfExecution2")]
        public int PeriodOfExecution2 { get; set; } // int

        [JsonPropertyName("periodOfExecution3")]
        public int PeriodOfExecution3 { get; set; } // int

        [JsonPropertyName("postPaymant1")]
        public decimal PostPaymant1 { get; set; } // decimal(8, 3)

        [JsonPropertyName("postPaymant2")]
        public decimal PostPaymant2 { get; set; } // decimal(8, 3)

        [JsonPropertyName("postPaymant3")]
        public decimal PostPaymant3 { get; set; } // decimal(8, 3)

        [JsonPropertyName("postPaymantPeriod1")]
        public int PostPaymantPeriod1 { get; set; } // int

        [JsonPropertyName("postPaymantPeriod2")]
        public int PostPaymantPeriod2 { get; set; } // int

        [JsonPropertyName("postPaymantPeriod3")]
        public int PostPaymantPeriod3 { get; set; } // int

        [JsonPropertyName("accreditive")]
        public bool Accreditive { get; set; } // bit

        [JsonPropertyName("bankGuarantee")]
        public bool BankGuarantee { get; set; } // bit

        [JsonPropertyName("customDuty")]
        public bool CustomDuty { get; set; } // bit

        [JsonPropertyName("customFee")]
        public bool CustomFee { get; set; } // bit

        [JsonPropertyName("missingDeadlines")]
        public bool MissingDeadlines { get; set; } // bit

        [JsonPropertyName("poorQuality")]
        public bool PoorQuality { get; set; } // bit

        [JsonPropertyName("normsViolated")]
        public bool NormsViolated { get; set; } // bit

        [JsonPropertyName("experienceCooperation")]
        public bool ExperienceCooperation { get; set; } // bit

        [JsonPropertyName("experienceMarket")]
        public bool ExperienceMarket { get; set; } // bit

        [JsonPropertyName("fines")]
        public bool Fines { get; set; } // bit

        [JsonPropertyName("intermediary")]
        public bool Intermediary { get; set; } // bit

        [JsonPropertyName("productionAndInventory")]
        public bool ProductionAndInventory { get; set; } // bit

        [JsonPropertyName("modernEquipment")]
        public bool ModernEquipment { get; set; } // bit

        [JsonPropertyName("georgraphy")]
        public bool Geography { get; set; }

        [JsonPropertyName("concessions")]
        public bool Concessions { get; set; }

        [JsonPropertyName("complaints")]
        public bool Complaints { get; set; }
    }
}
