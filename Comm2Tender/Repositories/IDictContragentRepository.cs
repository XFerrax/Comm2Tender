using Comm2Tender.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Comm2Tender.Repositories
{
    public interface IDictContragentRepository
    {
        Task AddContractor(DictContragent dict_Contragent);
        IQueryable<DictContragent> GetAllContractors();
    }
}
