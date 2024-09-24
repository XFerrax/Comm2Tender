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
    public class CustomFeeDictionaryController : ControllerBase
    {
        private readonly ILogicServiceCrud LogicService;

        public CustomFeeDictionaryController(ILogicService logicService)
        {
            LogicService = (ILogicServiceCrud)logicService;
        }

        // POST CustomFeeDictionary/Search
        [HttpPost("[action]")]
        public ActionResult<string> Search([FromBody] ListRequest listRequest)
        {
            return Ok(LogicService.SearchCustomFeeDictionary(listRequest));
        }

        // POST CustomFeeDictionary
        [HttpPost]
        public ActionResult<string> Post([FromBody] CustomFeeDictionary model)
        {
            return Ok(LogicService.AddCustomFeeDictionary(model));
        }

        // PUT CustomFeeDictionary/5
        [HttpPut]
        public ActionResult<string> Put([FromBody] CustomFeeDictionary model)
        {
            if (LogicService.UpdateCustomFeeDictionary(model))
            {
                return Ok();
            }
            return new NotFoundResult();
        }

        // DELETE CustomFeeDictionary/delete_fee/5
        [HttpDelete("delete_fee/{id:int}")]
        public ActionResult<string> Delete(int id)
        {
            if (LogicService.DeleteCustomFeeDictionary(id))
            {
                return Ok();
            }
            return new NotFoundResult();
        }

        [HttpGet("get_fee/{id:int}")]
        public ActionResult<string> GetFee(int id)
        {
            try
            {
                return Ok(LogicService.GetCustomFeeDictionary(id));
            }
            catch (System.Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}
