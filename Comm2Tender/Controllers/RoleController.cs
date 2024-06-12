﻿using Comm2Tender.Logic;
using Comm2Tender.Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Comm2Tender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly ILogicService LogicService;

        public RoleController(ILogicService logicService)
        {
            LogicService = logicService;
        }

        // POST Role/Search
        [HttpPost("[action]")]
        public ActionResult<string> Search([FromBody] ListRequest listRequest)
        {
            return Ok(LogicService.SearchRole(listRequest));
        }
    }
}
