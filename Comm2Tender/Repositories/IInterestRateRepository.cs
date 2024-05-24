using Comm2Tender.Models;

namespace Comm2Tender.Repositories
{
    public interface IInterestRateRepository
    {
        InterestRate GetInterestRate(int id);
    }
}
