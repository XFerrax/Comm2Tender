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
    [Authorize]
    public class PercentsDictionaryController : ControllerBase
    {
        private readonly ILogicServiceCrud LogicService;

        public PercentsDictionaryController(ILogicService logicService)
        {
            LogicService = (ILogicServiceCrud)logicService;
        }

        // POST PercentsDictionary/Search
        [HttpPost("[action]")]
        public ActionResult<string> Search([FromBody] ListRequest listRequest)
        {
            return Ok(LogicService.SearchPercentsDictionary(listRequest));
        }

        // POST PercentsDictionary
        [HttpPost]
        public ActionResult<string> Post([FromBody] PercentsDictionary model)
        {
            model.DateEnter = System.DateTime.UtcNow;
            return Ok(LogicService.AddPercentsDictionary(model));
        }

        // PUT PercentsDictionary/5
        [HttpPut]
        public ActionResult<string> Put([FromBody] PercentsDictionary model)
        {
            if (LogicService.UpdatePercentsDictionary(model))
            {
                return Ok();
            }
            return new NotFoundResult();
        }

        // DELETE PercentsDictionary/5
        [HttpDelete("delete_percents/{id:int}")]
        public ActionResult<string> Delete(int id)
        {
            if (LogicService.DeletePercentsDictionary(id))
            {
                return Ok();
            }
            return new NotFoundResult();
        }

        [HttpGet("get_percents/{id:int}")]
        public ActionResult<string> GetPercentsDictionary(int id)
        {
            try
            {
                return Ok(LogicService.GetPercentsDictionary(id));
            }
            catch (System.Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}
