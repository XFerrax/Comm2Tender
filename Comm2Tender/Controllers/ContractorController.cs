using Comm2Tender.Dtos;
using Comm2Tender.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;


namespace Comm2Tender.Controllers
{

    [ApiController]
    [Route("api/contragents")]
    public class ContractorController : ControllerBase
    {
        private readonly IDictContragentRepository contragentRepository;
        private readonly IVarContragentOfTenderRepository varContragentOfTenderRepository;
        private readonly IEconomicEffectVarRepository economicEffectVarRepository;

        public ContractorController(IDictContragentRepository contragentRepository,
            IVarContragentOfTenderRepository varContragentOfTenderRepository,
            IEconomicEffectVarRepository economicEffectVarRepository)
        {
            this.contragentRepository = contragentRepository;
            this.varContragentOfTenderRepository = varContragentOfTenderRepository;
            this.economicEffectVarRepository = economicEffectVarRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContractors()
        {
            return NotFound();
        }


        [HttpPost]
        public async Task CreateContractor([FromBody] object body)
        {
            var _contractorDto = JsonSerializer.Deserialize<ContractorDto>(body.ToString());

            //_contractorDto.VarContragentOfTender.EconomicEffectVar = _contractorDto.EconomicEffectVar;

            await contragentRepository.AddContractorAsync(_contractorDto);
            //await varContragentOfTenderRepository.AddVarContragentOfTenderAsync(_contractorDto.VarContragentOfTender);

            //await economicEffectVarRepository.AddEconomicEffectVarAsync(_contractorDto.EconomicEffectVar);


        }

    }
}
