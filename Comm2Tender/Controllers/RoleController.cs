using Comm2Tender.Logic.Models;
using Comm2Tender.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Comm2Tender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
