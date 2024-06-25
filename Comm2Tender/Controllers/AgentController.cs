using Comm2Tender.Logic;
using Comm2Tender.Logic.Constants;
using Comm2Tender.Logic.Models;
using Comm2Tender.Logic.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Comm2Tender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly ILogicServiceCrud LogicService;

        public AgentController(ILogicService logicService)
        {
            LogicService = (ILogicServiceCrud)logicService;
        }

        // POST Agent/Search
        [HttpPost("[action]")]
        public ActionResult<string> Search([FromBody] ListRequest listRequest)
        {
            return Ok(LogicService.SearchAgent(listRequest));
        }

        // POST Agent
        [HttpPost]
        public ActionResult<string> Post([FromBody] Agent model)
        {
            return Ok(LogicService.AddAgent(model));
        }

        // PUT Agent/5
        [HttpPut("{id:int:min(1)}")]
        public ActionResult<string> Put([FromBody] Agent model, int id)
        {
            model.AgentId = id;
            if (LogicService.UpdateAgent(model))
            {
                return Ok();
            }
            return new NotFoundResult();
        }

        // DELETE Agent/5
        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<string> Delete(int id)
        {
            if (LogicService.DeleteAgent(id))
            {
                return Ok();
            }
            return new NotFoundResult();
        }
    }
}
