using Comm2Tender.Contexts;
using Comm2Tender.Models;
using System.Threading.Tasks;

namespace Comm2Tender.Repositories
{
    public class EconomicEffectVarRepository : IEconomicEffectVarRepository
    {
        private readonly Comm2TenderDataBaseContext dataBaseContext;

        public EconomicEffectVarRepository(Comm2TenderDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public int AddEconomicEffectVar(EconomicEffectVar economicEffectVar)
        {
             var _dbEconomicEffectVar = dataBaseContext.EconomicEffectVars.Add(economicEffectVar);
             dataBaseContext.SaveChanges();

            return _dbEconomicEffectVar.Entity.Id;
        }
    }
}
