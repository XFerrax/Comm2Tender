using Comm2Tender.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Comm2Tender.Dtos
{
    public class ContractorDto
    {
        [JsonPropertyName("Dict_Contragent")]
        public DictContragent DictContragent { get; set; }
        
        [JsonPropertyName("Var_Contragent_Of_Tenders")]
        public VarContragentOfTender VarContragentOfTender { get; set; }

        [JsonPropertyName("Economic_effect_Var")]
        public EconomicEffectVar EconomicEffectVar { get; set; }
    }
}