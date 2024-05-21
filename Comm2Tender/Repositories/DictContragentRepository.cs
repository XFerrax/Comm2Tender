using Comm2Tender.Contexts;
using Comm2Tender.Dtos;
using Comm2Tender.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Comm2Tender.Repositories
{
    public class DictContragentRepository : IDictContragentRepository
    {

        private readonly Comm2TenderDataBaseContext dataBaseContext;

        public DictContragentRepository(Comm2TenderDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public async Task AddContractorAsync(ContractorDto contractorDto)
        {
            var _economicEffectVar = dataBaseContext.EconomicEffectVars.Add(contractorDto.EconomicEffectVar);
            dataBaseContext.SaveChanges();
            contractorDto.VarContragentOfTender.IdEconomicEffect = _economicEffectVar.Entity.Id;
            dataBaseContext.VarContragentOfTenders.Add(contractorDto.VarContragentOfTender);
            dataBaseContext.DictContragents.Add(contractorDto.DictContragent);
            
            
            await dataBaseContext.SaveChangesAsync();
        }

        public IQueryable<DictContragent> GetAllContractors()
        {
            return dataBaseContext.DictContragents.AsQueryable();
        }
    }
}
