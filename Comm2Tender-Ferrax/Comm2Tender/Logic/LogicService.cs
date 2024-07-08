using Comm2Tender.Data;
using Comm2Tender.Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;

namespace Comm2Tender.Logic
{
    public partial class LogicService : ILogicService
    {
        private readonly IHttpContextAccessor HttpContextAccessor;
        IDataService DataService { get; set; }
        IConfiguration Configuration { get; set; }

        public LogicService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IDataService dataService)
        {
            HttpContextAccessor = httpContextAccessor;
            DataService = dataService;
            Configuration = configuration;
        }

        private string GetIP()
        {
            return HttpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        private int GetUserTokenId()
        {
            try
            {
                var httpContext = HttpContextAccessor.HttpContext;
                var user = httpContext.User;
                var result = user.HasClaim(a => a.Type == Configuration["Jwt:ClaimNameToken"]) ?
                    int.Parse(HttpContextAccessor.HttpContext.User.FindFirstValue(Configuration["Jwt:ClaimNameToken"])) : 0;

                return result;
            }
            catch { return 0; }
        }

        private int GetUserId()
        {
            try
            {
                var httpContext = HttpContextAccessor.HttpContext;
                var user = httpContext.User;
                var id = user.HasClaim(a => a.Type == Configuration["Jwt:ClaimNameUser"]) ?
                    int.Parse(user.FindFirst(a => a.Type == Configuration["Jwt:ClaimNameUser"]).Value)
                    : 0;
                return id;
            }
            catch { return 0; }
        }

        private void ConfigListRequest(ListRequest listRequest)
        {
            //Logger.LogDebug($"Страница {listRequest.Page}, количество на странице {listRequest.Size}, поиск '{listRequest.Search}', сортировка {JsonSerializer.Serialize(listRequest.Sort)}, фильтрация {JsonSerializer.Serialize(listRequest.Filter)}");
            if (listRequest.IsActual)
            {
                listRequest.DateTime = DateTimeOffset.Now;
            }
            if (listRequest.Page == 0)
            {
                listRequest.Page = 1;
                //Logger.LogDebug($"Будет загружена страница {listRequest.Page}");
            }
            if (listRequest.Size == 0)
            {
                listRequest.Size = Configuration.GetValue<int>("Pagination:DefaultSize");
                //Logger.LogDebug($"Количество элементов на странице по умолчанию {listRequest.Size}");
            }
        }
    }
}
