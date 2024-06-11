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
    }
}
