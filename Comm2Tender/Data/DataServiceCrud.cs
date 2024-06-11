
using Comm2Tender.Logic.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Comm2Tender.Data
{
    public partial class DataService : IDataService
    {
        public List<Logic.Models.Dto.Role> SearchRole(ListRequest listRequest, out int total)
        {
            using var db = GetDatabase();
            var items = db.Role.WhereDynamic(listRequest.Filter);
            if (string.IsNullOrWhiteSpace(listRequest.Search) == false)
            {
                items = items.Where(a => a.Name.Contains(listRequest.Search));
            }
            items = items.OrderByDynamic(listRequest.Sort);
            total = items.Count();
            if (listRequest.Size > 0)
            {
                items = items.Skip((listRequest.Page - 1) * listRequest.Size).Take(listRequest.Size);
            }
            return items.ToList().ConvertAll(a => (Logic.Models.Dto.Role)a);
        }
    }
}
