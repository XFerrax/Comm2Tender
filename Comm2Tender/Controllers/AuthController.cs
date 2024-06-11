using Comm2Tender.Logic;
using Comm2Tender.Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NuGet.Protocol.Plugins;
using System;

namespace Comm2Tender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        ILogicService LogicService { get; set; }

        public AuthController(ILogicService logicService)
        {
            LogicService = logicService;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        // POST auth/login
        public ActionResult<string> Login([FromBody] LoginRequest model)
        {
            var response = LogicService.Login(model);
            switch (response.HttpCode)
            {
                case StatusCodes.Status200OK:
                    return Ok(response.Tokens);
                default: 
                    return StatusCode(response.HttpCode, new { response.Message });
            }
        }

        //[HttpGet("User")]
        //// GET auth/user
        //public ActionResult<string> GetUser()
        //{
        //    //return Ok(LogicService.GetUser());
        //}

        //[HttpGet("[action]")]
        //// GET auth/refresh
        //public ActionResult<string> Refresh()
        //{
        //    //if (LogicService.RefreshUserToken(out dynamic response))
        //    //{
        //    //    return Ok(response);
        //    //}
        //    //else
        //    //{
        //    //    return Unauthorized();
        //    //}
        //}

        [HttpGet("[action]")]
        // GET auth/logout
        public ActionResult Logout()
        {
            LogicService.Logout();
            return Ok();
        }

        [HttpPost("[action]")]
        // POST auth/change
        public ActionResult<string> ChangePassword([FromBody] ChangePasswordRequest model)
        {
            //if (LogicService.ChangePassword(model))
            //{
            //    return Ok();
            //}
            //LogicService.Logout(); // выход делать не будем, возможно пользователь ошибся при вводе пароля
            return UnprocessableEntity();
        }
    }
}
