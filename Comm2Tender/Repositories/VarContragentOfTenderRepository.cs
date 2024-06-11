using Comm2Tender.Contexts;
using Comm2Tender.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Comm2Tender.Repositories
{
    public class VarContragentOfTenderRepository : IVarContragentOfTenderRepository
    {
        private readonly Comm2TenderDataBaseContext dataBaseContext;

        public VarContragentOfTenderRepository(Comm2TenderDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public int? AddVarContragentOfTender(VarContragentOfTender varContragentOfTender)
        {
            var dbVarContragentOfTender = dataBaseContext.VarContragentOfTenders.Add(varContragentOfTender);
            dataBaseContext.SaveChanges();

            return dbVarContragentOfTender.Entity.IdTenders;
        }

        public VarContragentOfTender GetVarContragentOfTender(int contractorId)
        {
           return dataBaseContext.VarContragentOfTenders.FirstOrDefault(x => x.IdContragent ==  contractorId);
        }
    }
}
