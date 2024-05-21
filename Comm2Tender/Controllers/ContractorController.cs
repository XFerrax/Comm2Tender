using Comm2Tender.Dtos;
using Comm2Tender.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;


namespace Comm2Tender.Controllers
{
    
    [ApiController]
    [Route("api/contragents")]
    public class ContractorController : ControllerBase
    {
        private readonly IDictContragentRepository contragentRepository;

        public ContractorController(IDictContragentRepository contragentRepository)
        {
            this.contragentRepository = contragentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContractors()
        {
            return NotFound();
        }


        [HttpPost]
        public async Task CreateContractor([FromBody] string body)
        {
            var _contractorDto = JsonSerializer.Deserialize<ContractorDto>(body);
        }

    }
}
