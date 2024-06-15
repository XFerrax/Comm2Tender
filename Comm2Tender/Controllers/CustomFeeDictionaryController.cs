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
    [Authorize(Roles = RolesNames.ECONOMIST_ROLE_NAME)]
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
        [HttpPut("{id:int:min(1)}")]
        public ActionResult<string> Put([FromBody] CustomFeeDictionary model, int id)
        {
            model.CustomFeeDictionaryId = id;
            if (LogicService.UpdateCustomFeeDictionary(model))
            {
                return Ok();
            }
            return new NotFoundResult();
        }

        // DELETE CustomFeeDictionary/5
        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<string> Delete(int id)
        {
            if (LogicService.DeleteCustomFeeDictionary(id))
            {
                return Ok();
            }
            return new NotFoundResult();
        }
    }
}
