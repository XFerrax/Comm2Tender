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
    public class TenderController : ControllerBase
    {
        private readonly ILogicServiceCrud LogicService;

        public TenderController(ILogicService logicService)
        {
            LogicService = (ILogicServiceCrud)logicService;
        }

        // POST Tender/Search
        [HttpPost("[action]")]
        public ActionResult<string> Search([FromBody] ListRequest listRequest)
        {
            var tenders = LogicService.SearchTender(listRequest);
            return Ok(tenders);
        }

        // POST Tender
        [HttpPost]
        public ActionResult<string> Post([FromBody] Tender model)
        {
            return Ok(LogicService.AddTender(model));
        }

        // PUT Tender/5
        [HttpPut]
        public ActionResult<string> Put([FromBody] Tender model)
        {
            if (LogicService.UpdateTender(model))
            {
                return Ok();
            }
            return new NotFoundResult();
        }

        // DELETE Tender/5
        [HttpDelete("delete_tender/{id:int}")]
        public ActionResult<string> Delete(int id)
        {
            if (LogicService.DeleteTender(id))
            {
                return Ok();
            }
            return new NotFoundResult();
        }

        [HttpGet("get_tender/{id:int}")]
        public ActionResult<string> GetTender(int id)
        {
            try
            {
                return Ok(LogicService.GetTender(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
