using Comm2Tender.Logic.Models.Dto;

namespace Comm2Tender.Logic.Models
{
    /// <summary>
    /// Класс рассчета оценки надежности.
    /// </summary>
    public class CalcReliabilityAssessment
    {
        private decimal Missing_deadlines = 0.0233M;
        private decimal Norms_violated = 0.025M;
        private decimal Poor_quality = 0.05583M;

        public CalcReliabilityAssessment(CalcOrder order, Proposal proposal, PercentsDictionary percentsDictionary) 
        {
            Missing_deadlines = (percentsDictionary.RefinancingRate + percentsDictionary.Tmk) / 12m * 2m;
            Poor_quality = (percentsDictionary.RefinancingRate + percentsDictionary.Tmk) / 12m * 3.5m + 0.015M;

            Value = ((proposal.MissingDeadlines ? (-1) : (1)) * order.Value * Missing_deadlines)
                    + ((proposal.PoorQuality ? (-1) : (1)) * order.Value * Poor_quality)
                    + ((proposal.NormsViolated ? (-1) : (1)) * order.Value * Norms_violated);
        }

        public decimal Value { get; private set; }
    }
}
