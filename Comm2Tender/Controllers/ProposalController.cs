using Comm2Tender.Logic;
using Comm2Tender.Logic.Constants;
using Comm2Tender.Logic.Models;
using Comm2Tender.Logic.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace Comm2Tender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost]
        public ActionResult<string> Post([FromBody] ProposalViewModel model)
        {

            var proposal = new Proposal();
            proposal.Agent = new Agent();
            proposal.Tender = new Tender();
            proposal.User = new User();


            proposal.Agent.AgentId = model.AgentId;
            proposal.Tender.TenderId = model.TenderId;
            proposal.User.UserId = model.UserId;
            proposal.Accreditive = model.Accreditive;
            proposal.BankGuarantee = model.BankGuarantee;
            proposal.Complaints = model.Complaints;
            proposal.Concessions = model.Concessions;
            proposal.CountPos = model.CountPos;
            proposal.CustomDuty = model.CustomDuty;
            proposal.CustomFee = model.CustomFee;
            proposal.DeliveryCost = model.DeliveryCost;
            proposal.DeliveryTime = model.DeliveryTime;
            proposal.ExperienceCooperation = model.ExperienceCooperation;
            proposal.ExperienceMarket = model.ExperienceMarket;
            proposal.Fines = model.Fines;
            proposal.Georgraphy = model.Geography;
            proposal.Intermediary = model.Intermediary;
            proposal.MissingDeadlines = model.MissingDeadlines;
            proposal.ModernEquipment = model.ModernEquipment;
            proposal.NormsViolated = model.NormsViolated;
            proposal.PoorQuality = model.PoorQuality;
            proposal.PositionPrice = model.PositionPrice;
            proposal.PostPaymant1 = model.PostPaymant1;
            proposal.PostPaymant2 = model.PostPaymant2;
            proposal.PostPaymant3 = model.PostPaymant3;
            proposal.PostPaymantPeriod1 = model.PostPaymantPeriod1;
            proposal.PostPaymantPeriod2 = model.PostPaymantPeriod2;
            proposal.PostPaymantPeriod3 = model.PostPaymantPeriod3;
            proposal.PrepaidExpense1 = model.PrepaidExpense1;
            proposal.PrepaidExpense2 = model.PrepaidExpense2;
            proposal.PrepaidExpense3 = model.PrepaidExpense3;
            proposal.ProductionAndInventory = model.ProductionAndInventory;
            proposal.ProposalId = model.ProposalId;

            
            
            return Ok(LogicService.AddProposal(proposal));
        }

        // PUT Proposal/5
        [HttpPut]
        public ActionResult<string> Put([FromBody] ProposalViewModel model)
        {
            var proposal = new Proposal();
            proposal.Agent = new Agent();
            proposal.Tender = new Tender();
            proposal.User = new User();

            proposal.Agent.AgentId = model.AgentId;
            proposal.Tender.TenderId = model.TenderId;
            proposal.User.UserId = model.UserId;
            proposal.Accreditive = model.Accreditive;
            proposal.BankGuarantee = model.BankGuarantee;
            proposal.Complaints = model.Complaints;
            proposal.Concessions = model.Concessions;
            proposal.CountPos = model.CountPos;
            proposal.CustomDuty = model.CustomDuty;
            proposal.CustomFee = model.CustomFee;
            proposal.DeliveryCost = model.DeliveryCost;
            proposal.DeliveryTime = model.DeliveryTime;
            proposal.ExperienceCooperation = model.ExperienceCooperation;
            proposal.ExperienceMarket = model.ExperienceMarket;
            proposal.Fines = model.Fines;
            proposal.Georgraphy = model.Geography;
            proposal.Intermediary = model.Intermediary;
            proposal.MissingDeadlines = model.MissingDeadlines;
            proposal.ModernEquipment = model.ModernEquipment;
            proposal.NormsViolated = model.NormsViolated;
            proposal.PoorQuality = model.PoorQuality;
            proposal.PositionPrice = model.PositionPrice;
            proposal.PostPaymant1 = model.PostPaymant1;
            proposal.PostPaymant2 = model.PostPaymant2;
            proposal.PostPaymant3 = model.PostPaymant3;
            proposal.PostPaymantPeriod1 = model.PostPaymantPeriod1;
            proposal.PostPaymantPeriod2 = model.PostPaymantPeriod2;
            proposal.PostPaymantPeriod3 = model.PostPaymantPeriod3;
            proposal.PrepaidExpense1 = model.PrepaidExpense1;
            proposal.PrepaidExpense2 = model.PrepaidExpense2;
            proposal.PrepaidExpense3 = model.PrepaidExpense3;
            proposal.ProductionAndInventory = model.ProductionAndInventory;
            proposal.ProposalId = model.ProposalId;

            if (LogicService.UpdateProposal(proposal))
            {
                return Ok();
            }
            return new NotFoundResult();
        }

        // DELETE Proposal/5
        [HttpDelete("{id:int}")]
        public ActionResult<string> Delete(int id)
        {
            if (LogicService.DeleteProposal(id))
            {
                return Ok();
            }
            return new NotFoundResult();
        }

        [HttpGet("tender_proposals/{id}")]
        public ActionResult<string> GetTenderProposals(int id)
        {
            try
            {
                var proposals = LogicService.GetTenderProposals(id);
                return Ok(proposals);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<string> GetProposal(int id)
        {
            try
            {
                var proposal = LogicService.GetProposal(id);
                return Ok(proposal);
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}
