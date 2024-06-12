using Comm2Tender.Logic.Models.Dto;
using Comm2Tender.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Comm2Tender.Logic.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comm2Tender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PercentsDictionaryController : ControllerBase
    {
        private readonly ILogicService LogicService;

        //public PercentsDictionaryController(ILogicService logicService)
        //{
        //    LogicService = logicService;
        //}

        //// POST PercentsDictionary/Search
        //[HttpPost("[action]")]
        //public ActionResult<string> Search([FromBody] ListRequest listRequest)
        //{
        //    return Ok(LogicService.SearchPercentsDictionary(listRequest));
        //}

        //// POST PercentsDictionary
        //[HttpPost]
        //public ActionResult<string> Post([FromBody] PercentsDictionary model)
        //{
        //    LogicService.AddPercentsDictionary(model, out AddResponse response);
        //    return Ok(response);
        //}

        //// PUT PercentsDictionary/5
        //[HttpPut("{id:int:min(1)}")]
        //public ActionResult<string> Put([FromBody] PercentsDictionary model, int id)
        //{
        //    if (LogicService.UpdatePercentsDictionary(model) == false) throw new NotFoundException();
        //    return Ok();
        //}

        //// DELETE PercentsDictionary/5
        //[HttpDelete("{id:int:min(1)}")]
        //public ActionResult<string> Delete(int id)
        //{
        //    if (LogicService.DeletePercentsDictionary(id) == false) throw new NotFoundException();
        //    return Ok();
        //}
    }
}
