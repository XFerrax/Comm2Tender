
using Comm2Tender.Logic.Models;
using LinqToDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

        #region Agent
        public int AddAgent(Agent model)
        {
            using var db = GetDatabase();
            return db.InsertWithInt32Identity<Agent>(model);
        }

        public bool DeleteAgent(int id)
        {
            using var db = GetDatabase();
            return db.Agent.Where(a => a.AgentId == id).Delete() == 1;
        }

        public (List<Logic.Models.Dto.Agent> listRequest, int total) SearchAgent(ListRequest listRequest)
        {
            using var db = GetDatabase();
            var items = db.Agent
                .WhereDynamic(listRequest.Filter);
            if (string.IsNullOrWhiteSpace(listRequest.Search) == false)
            {
                items = items.Where(a => a.Name.Contains(listRequest.Search));
            }
            items = items.OrderByDynamic(listRequest.Sort);
            var total = items.Count();
            if (listRequest.Size > 0)
            {
                items = items.Skip((listRequest.Page - 1) * listRequest.Size).Take(listRequest.Size);
            }
            return (items.ToList().ConvertAll(a => (Logic.Models.Dto.Agent)a), total);
        }

        public bool UpdateAgent(Agent model)
        {
            using var db = GetDatabase();
            db.Update<Agent>(model);
            return true;
        }
        #endregion Agent

        #region CustomFeeDictionary
        public int AddCustomFeeDictionary(CustomFeeDictionary model)
        {
            using var db = GetDatabase();
            return db.InsertWithInt32Identity<CustomFeeDictionary>(model);
        }

        public bool DeleteCustomFeeDictionary(int id)
        {
            using var db = GetDatabase();
            return db.CustomFeeDictionary.Where(a => a.CustomFeeDictionaryId == id).Delete() == 1;
        }
        public (List<Logic.Models.Dto.CustomFeeDictionary> listRequest, int total) SearchCustomFeeDictionary(ListRequest listRequest)
        {
            using var db = GetDatabase();
            var items = db.CustomFeeDictionary
                .WhereDynamic(listRequest.Filter);
            if (string.IsNullOrWhiteSpace(listRequest.Search) == false)
            {

            }
            items = items.OrderByDynamic(listRequest.Sort);
            var total = items.Count();
            if (listRequest.Size > 0)
            {
                items = items.Skip((listRequest.Page - 1) * listRequest.Size).Take(listRequest.Size);
            }
            return (items.ToList().ConvertAll(a => (Logic.Models.Dto.CustomFeeDictionary)a), total);
        }
        public bool UpdateCustomFeeDictionary(CustomFeeDictionary model)
        {
            using var db = GetDatabase();
            db.Update<CustomFeeDictionary>(model);
            return true;
        }
        #endregion CustomFeeDictionary

        #region PercentsDictionary
        public int AddPercentsDictionary(PercentsDictionary model)
        {
            using var db = GetDatabase();
            return db.InsertWithInt32Identity<PercentsDictionary>(model);
        }

        public bool DeletePercentsDictionary(int id) 
        {
            using var db = GetDatabase();
            return db.PercentsDictionary.Where(a => a.PercentsDictionaryId == id).Delete() == 1;
        }
        public (List<Logic.Models.Dto.PercentsDictionary> listRequest, int total) SearchPercentsDictionary(ListRequest listRequest)
        {
            using var db = GetDatabase();
            var items = db.PercentsDictionary
                .WhereDynamic(listRequest.Filter);
            if (string.IsNullOrWhiteSpace(listRequest.Search) == false)
            {

            }
            items = items.OrderByDynamic(listRequest.Sort);
            var total = items.Count();
            if (listRequest.Size > 0)
            {
                items = items.Skip((listRequest.Page - 1) * listRequest.Size).Take(listRequest.Size);
            }
            return (items.ToList().ConvertAll(a => (Logic.Models.Dto.PercentsDictionary)a), total);
        }
        public bool UpdatePercentsDictionary(PercentsDictionary model)
        {
            using var db = GetDatabase();
            db.Update<PercentsDictionary>(model);
            return true;
        }
        #endregion PercentsDictionary
    }
}
