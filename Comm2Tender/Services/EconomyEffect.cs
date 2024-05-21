using Comm2Tender.Repositories;

namespace Comm2Tender.Services
{
    public class EconomyEffect
    {
        public EconomyEffect(
            IC_Zakaz zakaz, 
            IInterestRateRepository interest, 
            IСustomsDutyRepository сustomsDutyRepository, 
            IEconomicEffectVarRepository economicEffectVarRepository,
            IVarContragentOfTenderRepository varContragentOfTenderRepository)
        {
            for (int i = 0; i <= 730; i = i + 5)
            {
                if(i= varContragentOfTenderRepository.)
            }
        }


        public float Value { get; private set; }
    }
}
