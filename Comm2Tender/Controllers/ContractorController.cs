using Comm2Tender.Dtos;
using Comm2Tender.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace Comm2Tender.Controllers
{

    [ApiController]
    [Route("api/contragents")]
    public class ContractorController : ControllerBase
    {
        private readonly IContragentRepository contragentRepository;
        private readonly IVarContragentOfTenderRepository varContragentOfTenderRepository;
        private readonly IEconomicEffectVarRepository economicEffectVarRepository;

        public ContractorController(IContragentRepository contragentRepository,
            IVarContragentOfTenderRepository varContragentOfTenderRepository,
            IEconomicEffectVarRepository economicEffectVarRepository)
        {
            this.contragentRepository = contragentRepository;
            this.varContragentOfTenderRepository = varContragentOfTenderRepository;
            this.economicEffectVarRepository = economicEffectVarRepository;
        }

        [HttpGet]
        public async Task GetAllContractors()
        {
            var _mainPageDtos = new List<MainPageDto>();

            var _contragents = contragentRepository.GetAllContractors().ToList();
            foreach (var _contragent in _contragents)
            {
                var _mainPageDto = new MainPageDto();
                _mainPageDto.Counterparty = _contragent.Counterparty;
                //Добавить расчетные поля для Dto _mainPageDto


                _mainPageDtos.Add(_mainPageDto);
            }

            await HttpContext.Response.WriteAsJsonAsync(_mainPageDtos);
        }


        [HttpPost]
        public async Task CreateContractor([FromBody] object body)
        {
            var _contractorDto = JsonSerializer.Deserialize<ContractorDto>(body.ToString());

            var _contragentId = contragentRepository.AddContractor(_contractorDto.DictContragent);

            _contractorDto.VarContragentOfTender.IdContragent = _contragentId;

            varContragentOfTenderRepository.AddVarContragentOfTender(_contractorDto.VarContragentOfTender);

            economicEffectVarRepository.AddEconomicEffectVar(_contractorDto.EconomicEffectVar);
        }
    }
}
