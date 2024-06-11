using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Comm2Tender.Logic;

namespace Comm2Tender.Middleware
{
    public class AuthorizationAsyncResourceFilter : IAsyncResourceFilter
    {
        private readonly ILogicService LogicService;

        public AuthorizationAsyncResourceFilter(ILogicService logicService)
        {
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var descriptor = ((ControllerActionDescriptor)context.ActionDescriptor);

            //if (LogicService.CheckControllerAction(descriptor.ControllerName, descriptor.ActionName) == false)
            //{
            //    throw new Exception();
            //}
            await next();
        }
    }
}
