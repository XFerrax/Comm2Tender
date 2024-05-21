using Comm2Tender.Contexts;
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

        public async Task AddContractor(DictContragent dict_Contragent)
        {
           await dataBaseContext.DictContragents.AddAsync(dict_Contragent);
           await dataBaseContext.SaveChangesAsync();
        }

        public IQueryable<DictContragent> GetAllContractors()
        {
            return dataBaseContext.DictContragents.AsQueryable();
        }
    }
}
