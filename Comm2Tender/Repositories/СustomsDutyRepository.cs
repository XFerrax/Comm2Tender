using Comm2Tender.Contexts;
using System.Linq;

namespace Comm2Tender.Repositories
{
    public class СustomsDutyRepository : IСustomsDutyRepository
    {

        private readonly Comm2TenderDataBaseContext dataBaseContext;

        public СustomsDutyRepository(Comm2TenderDataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public double? GetCustomsDuty(double? zakazValue)
        {
            var _customDuty = dataBaseContext.СustomsDuties.FirstOrDefault(x => x.MinPrice < zakazValue && x.MaxPrice > zakazValue);
            return _customDuty != null ? _customDuty.SumСustomsDuty : 0;
        }
    }
}
