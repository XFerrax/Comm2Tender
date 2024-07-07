namespace Comm2TenderBlazor.Models.Dto
{
    using System;
    using System.Text.Json.Serialization;

    public class PercentsDictionary
    {
        [JsonPropertyName("percentsDictionaryId")]
        public int PercentsDictionaryId { get; set; } // int

        [JsonPropertyName("dateEnter")]
        public DateTime DateEnter { get; set; } // datetime

        [JsonPropertyName("refinancingRate")]
        public decimal RefinancingRate { get; set; } // decimal(4, 3)

        [JsonPropertyName("tmk")]
        public decimal Tmk { get; set; } // decimal(4, 3)

        [JsonPropertyName("bankGuarantee")]
        public decimal BankGuarantee { get; set; } // decimal(4, 3)

        [JsonPropertyName("credit")]
        public decimal Credit { get; set; } // decimal(4, 3)

        [JsonPropertyName("customDuty")]
        public decimal CustomDuty { get; set; } // decimal(4, 3)

        [JsonPropertyName("discount")]
        public decimal Discount { get; set; } // decimal(4, 3)

    }
}
