using Comm2Tender.Dtos;
using Comm2Tender.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Comm2Tender.Repositories
{
    public interface IDictContragentRepository
    {
        //Task AddContractorAsync(DictContragent dict_Contragent);
        Task AddContractorAsync(ContractorDto contractorDto);
        IQueryable<DictContragent> GetAllContractors();
    }
}
