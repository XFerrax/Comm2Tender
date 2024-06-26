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
            return Ok(LogicService.SearchTender(listRequest));
        }

        // POST Tender
        [HttpPost]
        public ActionResult<string> Post([FromBody] Tender model)
        {
            return Ok(LogicService.AddTender(model));
        }

        // PUT Tender/5
        [HttpPut("{id:int:min(1)}")]
        public ActionResult<string> Put([FromBody] Tender model, int id)
        {
            model.TenderId = id;
            if (LogicService.UpdateTender(model))
            {
                return Ok();
            }
            return new NotFoundResult();
        }

        // DELETE Tender/5
        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<string> Delete(int id)
        {
            if (LogicService.DeleteTender(id))
            {
                return Ok();
            }
            return new NotFoundResult();
        }
    }
}
