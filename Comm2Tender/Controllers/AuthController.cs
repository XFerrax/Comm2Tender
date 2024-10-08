﻿using Comm2Tender.Logic;
using Comm2Tender.Logic.Constants;
using Comm2Tender.Logic.Enum;
using Comm2Tender.Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Comm2Tender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        ILogicServiceAuth LogicService { get; set; }

        public AuthController(ILogicService logicService)
        {
            LogicService = (ILogicServiceAuth)logicService;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        // POST auth/login
        public ActionResult<string> Login([FromBody] LoginRequest model)
        {
            var response = LogicService.Login(model);

            if (response.HttpCode == StatusCodes.Status200OK)
            {
                return Ok(response.Tokens);
            }

            return StatusCode(response.HttpCode, new { response.Message });

        }


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

        // GET auth/getUserView
        [HttpGet("[action]")]
        //[AllowAnonymous]
        public ActionResult<string> GetUserView()
        {
            var response = LogicService.GetUserView();
            return Ok(response);
        }
    }
}
