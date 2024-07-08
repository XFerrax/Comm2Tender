namespace Comm2TenderBlazor.Models.Dto
{
	using System.Text.Json.Serialization;

	public class Calculation
    {
	    [JsonPropertyName("proposalId")]
		public int ProposalId { get; set; }

	    [JsonPropertyName("agentName")]
		public string AgentName { get; set; }

	    [JsonPropertyName("positionPrice")]
		public decimal PositionPrice { get; set; }

	    [JsonPropertyName("economyEffect")]
		public decimal EconomyEffect { get; set; }

	    [JsonPropertyName("reliabilityAssessment")]
		public decimal ReliabilityAssessment { get; set; }

	    [JsonPropertyName("integralAssessment")]
		public decimal IntegralAssessment { get; set; }

	    [JsonPropertyName("note")]
		public string Note { get; set; }
    }
}
