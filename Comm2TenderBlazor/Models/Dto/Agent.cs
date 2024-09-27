namespace Comm2TenderBlazor.Models.Dto
{
    using System.Text.Json.Serialization;

    public class Agent
    {
        [JsonPropertyName("agentId")]
        public int AgentId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("agentRegistrationDate")]
        public DateTime AgentRegistrationDate { get; set; }
        [JsonPropertyName("ogrn")]
        public decimal OGRN { get; set; }
        [JsonPropertyName("inn")]
        public decimal INN { get; set; }
        [JsonPropertyName("kpp")]
        public decimal KPP { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
	}
}
