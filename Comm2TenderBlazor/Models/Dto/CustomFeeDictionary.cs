namespace Comm2TenderBlazor.Models.Dto
{
    using System.Text.Json.Serialization;

    public class CustomFeeDictionary
    {
        [JsonPropertyName("customFeeDictionaryId")]
        public int CustomFeeDictionaryId { get; set; } // int
        [JsonPropertyName("minAmount")]
        public decimal MinAmount { get; set; } // decimal(13, 3)
        [JsonPropertyName("summaryCustomFee")]
        public decimal SummaryCustomFee { get; set; } // decimal(11, 3)

    }
}
