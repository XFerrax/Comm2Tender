using Comm2Tender.Logic;
using Comm2Tender.Logic.Constants;
using Comm2Tender.Logic.Models;
using Comm2Tender.Logic.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet("get_agent/{id:int}")]
        public ActionResult<string> GetAgent(int id)
        {
            try
            {
                return Ok(LogicService.GetAgent(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
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
            model.AgentSystemRegistrationDate =  DateTime.UtcNow;
            return Ok(LogicService.AddAgent(model));
        }

        // PUT Agent/5
        [HttpPut()]
        public ActionResult<string> Put([FromBody] Agent model)
        {
            if (LogicService.UpdateAgent(model))
            {
                return Ok();
            }
            return new NotFoundResult();
        }

        // DELETE Agent/delete_agent/5
        [HttpDelete("delete_agent/{id:int:min(1)}")]
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
