using Comm2Tender.Logic.Models;

namespace Comm2Tender.Logic
{
    public partial interface ILogicService
    {
        ListResponse SearchRole(ListRequest listRequest);
    }
}
