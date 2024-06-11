using Comm2Tender.Contexts;
using Comm2Tender.Models;
using System.Linq;

namespace Comm2Tender.Repositories
{
    public class InterestRateRepository : IInterestRateRepository
    {
        private readonly Comm2TenderDataBaseContext dataBaseContext;

        public InterestRateRepository(Comm2TenderDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public InterestRate GetInterestRate(int id)
        {
            return dataBaseContext.InterestRates.FirstOrDefault();
        }
    }
}
