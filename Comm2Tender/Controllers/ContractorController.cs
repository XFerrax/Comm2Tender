//using Comm2Tender.Dtos;
//using Comm2Tender.Repositories;
//using Comm2Tender.Services;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.Json;
//using System.Threading.Tasks;


//namespace Comm2Tender.Controllers
//{

//    [ApiController]
//    [Route("api/contragents")]
//    public class ContractorController : ControllerBase
//    {
//        private readonly IContragentRepository contragentRepository;
//        private readonly IVarContragentOfTenderRepository varContragentOfTenderRepository;
//        private readonly IEconomicEffectVarRepository economicEffectVarRepository;
//        private readonly IInterestRateRepository interestRateRepository;
//        private readonly IСustomsDutyRepository сustomsDutyRepository;

//        public ContractorController(IContragentRepository contragentRepository,
//            IVarContragentOfTenderRepository varContragentOfTenderRepository,
//            IEconomicEffectVarRepository economicEffectVarRepository,
//            IInterestRateRepository interestRateRepository,
//            IСustomsDutyRepository сustomsDutyRepository)
//        {
//            this.contragentRepository = contragentRepository;
//            this.varContragentOfTenderRepository = varContragentOfTenderRepository;
//            this.economicEffectVarRepository = economicEffectVarRepository;
//            this.interestRateRepository = interestRateRepository;
//            this.сustomsDutyRepository = сustomsDutyRepository;
//        }

//        [HttpGet]
//        public async Task GetAllContractors()
//        {
//            var _mainPageDtos = new List<MainPageDto>();

//            var _contragents = contragentRepository.GetAllContractors().ToList();
//            foreach (var _contragent in _contragents)
//            {
                

//                var _varContragentOfTender = varContragentOfTenderRepository.GetVarContragentOfTender(_contragent.Id);
//                var _economicEffectVar = economicEffectVarRepository.GetEconomicEffectVar(_contragent.Id);
//                var _interestRate = interestRateRepository.GetInterestRate(_contragent.Id);
                

//                var _cZakaz = new C_Zakaz(_varContragentOfTender.CountPos, _varContragentOfTender.PositionPrice, _varContragentOfTender.DeliveryCost);

//                var _relaitbilityAssessments = new ReliabilityAssessment(_cZakaz, _economicEffectVar.MissingDeadlines, _economicEffectVar.PoorQuality, _economicEffectVar.NormsViolated);

//                var _sumCustom = сustomsDutyRepository.GetCustomsDuty(_cZakaz.Value);

//                var _economyEffect = new EconomyEffect(_cZakaz, _interestRate, _economicEffectVar, _varContragentOfTender, _sumCustom);

//                var _mainPageDto = new MainPageDto();
//                _mainPageDto.Counterparty = _contragent.Counterparty;
//                _mainPageDto.CZakazValue = _cZakaz.Value;
//                _mainPageDto.EconomicEffectValue = _economyEffect.Value;
//                _mainPageDto.ReliabilityAssessmentValue = _relaitbilityAssessments.Value;
//                _mainPageDto.IntegratedAssessmentsValue = _cZakaz.Value - _economyEffect.Value - _relaitbilityAssessments.Value;

//                _mainPageDtos.Add(_mainPageDto);
//            }

//            await HttpContext.Response.WriteAsJsonAsync(_mainPageDtos);
//        }


//        [HttpPost]
//        public async Task CreateContractor([FromBody] object body)
//        {
//            var _contractorDto = JsonSerializer.Deserialize<ContractorDto>(body.ToString());

//            var _contragentId = contragentRepository.AddContractor(_contractorDto.DictContragent);

//            _contractorDto.VarContragentOfTender.IdContragent = _contragentId;
//            _contractorDto.EconomicEffectVar.IdTendes = _contragentId;

//            varContragentOfTenderRepository.AddVarContragentOfTender(_contractorDto.VarContragentOfTender);

//            economicEffectVarRepository.AddEconomicEffectVar(_contractorDto.EconomicEffectVar);
//        }
//    }
//}
