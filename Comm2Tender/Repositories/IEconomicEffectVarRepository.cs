using Comm2Tender.Models;
using System.Threading.Tasks;

namespace Comm2Tender.Repositories
{
    public interface IEconomicEffectVarRepository
    {
        int AddEconomicEffectVar(EconomicEffectVar economicEffectVar);
        EconomicEffectVar GetEconomicEffectVar(int contractorId);
    }
}
