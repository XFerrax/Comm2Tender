namespace Comm2Tender.Services
{
    public class ReliabilityAssessment : IReliabilityAssessment
    {
        private float Norms_violated = 0.025F;

        public ReliabilityAssessment(IC_Zakaz zakaz, bool isMissing_deadlines, bool isPoor_quality, bool isNorms_violated)
        {
            //Value = ((isMissing_deadlines ? (-1) : (1)) * zakaz.Value * Missing_deadlines)
            //    + ((isPoor_quality ? (-1) : (1)) * zakaz.Value * Poor_quality)
            //    + ((isNorms_violated ? (-1) : (1)) * zakaz.Value * Norms_violated);
        }

        public double? Value { get; private set; }
    }
}
