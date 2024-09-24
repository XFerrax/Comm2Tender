using Comm2Tender.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Comm2Tender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CalculationController : ControllerBase
    {

        private readonly ILogicServiceCalculation LogicService;

        public CalculationController(ILogicService logicService)
        {
            LogicService = (ILogicServiceCalculation)logicService;
        }

        [HttpGet("get_calc/{id:int}")]
        public ActionResult<string> GetCalculation(int id)
        {
            return Ok(LogicService.Calculate(id));
        }
    }
}
