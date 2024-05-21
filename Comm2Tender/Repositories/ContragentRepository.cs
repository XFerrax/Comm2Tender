using Comm2Tender.Contexts;
using Comm2Tender.Dtos;
using Comm2Tender.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Comm2Tender.Repositories
{
    public class ContragentRepository : IContragentRepository
    {

        private readonly Comm2TenderDataBaseContext dataBaseContext;

        public ContragentRepository(Comm2TenderDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public int AddContractor(DictContragent contragent)
        {
            var dbContragent = dataBaseContext.DictContragents.Add(contragent);
            dataBaseContext.SaveChanges();

            return dbContragent.Entity.Id;
        }

        public IQueryable<DictContragent> GetAllContractors()
        {
            return dataBaseContext.DictContragents.AsQueryable();
        }
    }
}
