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
    [Authorize(Roles = RolesNames.SPECIALIST_ROLE_NAME)]
    public class ProposalController : ControllerBase
    {
        private readonly ILogicServiceCrud LogicService;

        public ProposalController(ILogicService logicService)
        {
            LogicService = (ILogicServiceCrud)logicService;
        }

        // POST Proposal/Search
        [HttpPost("[action]")]
        public ActionResult<string> Search([FromBody] ListRequest listRequest)
        {
            return Ok(LogicService.SearchProposal(listRequest));
        }

        // POST Proposal
        [HttpPost]
        public ActionResult<string> Post([FromBody] Proposal model)
        {
            return Ok(LogicService.AddProposal(model));
        }

        // PUT Proposal/5
        [HttpPut("{id:int:min(1)}")]
        public ActionResult<string> Put([FromBody] Proposal model, int id)
        {
            model.ProposalId = id;
            if (LogicService.UpdateProposal(model))
            {
                return Ok();
            }
            return new NotFoundResult();
        }

        // DELETE Proposal/5
        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<string> Delete(int id)
        {
            if (LogicService.DeleteProposal(id))
            {
                return Ok();
            }
            return new NotFoundResult();
        }
    }
}
