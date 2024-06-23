using Comm2Tender.Logic;
using Comm2Tender.Logic.Constants;
using Comm2Tender.Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Linq;

namespace Comm2Tender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = RolesNames.ECONOMIST_ROLE_NAME)]
    [Authorize]
    public class ExcelController : ControllerBase
    {
        private readonly ILogicServiceExcel LogicService;

        public ExcelController(ILogicService logicService)
        {
            LogicService = (ILogicServiceExcel)logicService;
        }


        // POST Excel
        [HttpPost]
        public ActionResult Post()
        {
            try
            {
                var file = Request.Form.Files.First();

                LogicService.LoadExcelToDataBase(file);

                return Ok("Загружено");
               
            }
            catch (Exception ex)
            {
                var message = $"Не загрузилось с ошибкой: {ex.Message} и стеком вызовов {ex.StackTrace}";
                return BadRequest(message);
            }
        }

    }
}
