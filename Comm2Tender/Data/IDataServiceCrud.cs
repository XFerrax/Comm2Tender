using Comm2Tender.Logic.Models;
using System.Collections.Generic;

namespace Comm2Tender.Data
{
    public partial interface IDataService
    {
        List<Logic.Models.Dto.Role> SearchRole(ListRequest listRequest, out int total);
    }
}
