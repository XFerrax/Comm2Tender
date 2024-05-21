namespace Comm2Tender.Services
{
    public class ReliabilityAssessment : IReliabilityAssessment
    {
        public ReliabilityAssessment(IC_Zakaz zakaz, bool isMissing_deadlines, bool isPoor_quality, bool isNorms_violated)
        {
            Value = ((isMissing_deadlines ? (-1) : (1)) * zakaz.Value * Missing_deadlines)
                + ((isPoor_quality ? (-1) : (1)) * zakaz.Value * Poor_quality)
                + ((isNorms_violated ? (-1) : (1)) * zakaz.Value * Norms_violated);
        }

        private float Missing_deadlines = 0.0233F;
        private float Norms_violated = 0.025F;
        private float Poor_quality = 0.05583F;

        public double Value { get; private set; }
    }
}
