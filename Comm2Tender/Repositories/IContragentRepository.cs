using Comm2Tender.Dtos;
using Comm2Tender.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Comm2Tender.Repositories
{
    public interface IContragentRepository
    {
        int AddContractor(DictContragent dict_Contragent);
        IQueryable<DictContragent> GetAllContractors();
    }
}
