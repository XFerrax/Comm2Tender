using Comm2Tender.Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System;
using System.Security.Claims;
using Comm2Tender.Data;
using Microsoft.Extensions.Configuration;

namespace Comm2Tender.Logic
{
    public partial class LogicService : ILogicService
    {
        #region Role
        public ListResponse SearchRole(ListRequest listRequest)
        {
            ConfigListRequest(listRequest);
            return new ListResponse { Items = DataService.SearchRole(listRequest, out int total), Total = total };
        }
        #endregion

        #region Agent
        public AddResponse AddAgent(Agent model)
        {
            return new AddResponse
            {
                Id = DataService.AddAgent(model),
            };
        }

        public bool DeleteAgent(int id)
        {
            return DataService.DeleteAgent(id);
        }

        public ListResponse SearchAgent(ListRequest listRequest)
        {
            var respList = DataService.SearchAgent(listRequest);
            return new ListResponse() { Items = respList.listRequest, Total = respList.total };
        }

        public bool UpdateAgent(Agent model)
        {
            return DataService.UpdateAgent(model);
        }
        #endregion Agent

        #region CustomFeeDictionary
        public AddResponse AddCustomFeeDictionary(CustomFeeDictionary model)
        {
            return new AddResponse
            {
                Id = DataService.AddCustomFeeDictionary(model),
            };
        }

        public bool DeleteCustomFeeDictionary(int id)
        {
            return DataService.DeleteCustomFeeDictionary(id);
        }

        public ListResponse SearchCustomFeeDictionary(ListRequest listRequest)
        {
            var respList = DataService.SearchCustomFeeDictionary(listRequest);
            return new ListResponse() { Items = respList.listRequest, Total = respList.total };
        }

        public bool UpdateCustomFeeDictionary(CustomFeeDictionary model)
        {
            return DataService.UpdateCustomFeeDictionary(model);
        }
        #endregion CustomFeeDictionary

        #region PercentsDictionary
        public AddResponse AddPercentsDictionary(PercentsDictionary model) 
        {
            return new AddResponse
            {
                Id = DataService.AddPercentsDictionary(model),
            };
        }

        public bool DeletePercentsDictionary(int id)
        {
            return DataService.DeletePercentsDictionary(id);
        }
        public ListResponse SearchPercentsDictionary(ListRequest listRequest)
        {
            var respList = DataService.SearchPercentsDictionary(listRequest);
            return new ListResponse() { Items = respList.listRequest, Total = respList.total };
        }

        public bool UpdatePercentsDictionary(PercentsDictionary model)
        {
            return DataService.UpdatePercentsDictionary(model);
        }
        #endregion PercentsDictionary
    }
}
