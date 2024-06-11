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
        IHttpContextAccessor HttpContextAccessor { get; set; }
        IDataService DataService { get; set; }
        IConfiguration Configuration { get; set; }

        public LogicService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IDataService dataService)
        {
            HttpContextAccessor = httpContextAccessor ?? new HttpContextAccessor();
            DataService = dataService ?? new DataService(Configuration);
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
                return HttpContextAccessor.HttpContext.User.HasClaim(a => a.Type == "sub") ?
                    int.Parse(HttpContextAccessor.HttpContext.User.FindFirstValue("sub"))
                    : 0;
            }
            catch { return 0; }
        }

        private int GetUserId()
        {
            try
            {
                return HttpContextAccessor.HttpContext.User.HasClaim(a => a.Type == ClaimTypes.NameIdentifier) ?
                    int.Parse(HttpContextAccessor.HttpContext.User.FindFirst(a => a.Type == ClaimTypes.NameIdentifier).Value)
                    : 0;
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
