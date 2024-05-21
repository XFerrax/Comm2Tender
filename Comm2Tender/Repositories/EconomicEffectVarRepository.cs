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

        public async Task AddEconomicEffectVarAsync(EconomicEffectVar economicEffectVar)
        {
            await dataBaseContext.EconomicEffectVars.AddAsync(economicEffectVar);
            await dataBaseContext.SaveChangesAsync();
        }
    }
}
