namespace Comm2Tender.Logic.Models.Dto
{
    public class Calculation
    {
        public int ProposalId { get; set; }
        public string AgentName { get; set; }
        public decimal PositionPrice { get; set; }
        public decimal EconomyEffect { get; set; }
        public decimal ReliabilityAssessment { get; set; }
        public decimal IntegralAssessment { get; set; }
        public string Note { get; set; }
    }
}
