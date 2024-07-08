using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comm2Tender.Logic.Models.Dto
{
    public class Agent
    {
        public int AgentId { get; set; }
        public string Name { get; set; }
        public DateTime AgentRegistrationDate { get; set; }
        public DateTime AgentSystemRegistrationDate { get; set; }
        public decimal OGRN { get; set; }
        public decimal INN { get; set; }
        public decimal KPP { get; set; }

        public static implicit operator Agent(Data.Agent a)
        {
            if (a == null) return null;

            return new Agent()
            {
                AgentId = a.AgentId,
                Name = a.Name,
                AgentRegistrationDate = a.AgentRegistrationDate,
                AgentSystemRegistrationDate = a.AgentSystemRegistrationDate,
                OGRN = a.OGRN,
                INN = a.INN,
                KPP = a.KPP,
            };
        }

        public static implicit operator Data.Agent(Agent a)
        {
            if (a == null) return null;

            return new Data.Agent()
            {
                AgentId = a.AgentId,
                Name = a.Name,
                AgentRegistrationDate = a.AgentRegistrationDate,
                AgentSystemRegistrationDate = a.AgentSystemRegistrationDate,
                OGRN = a.OGRN,
                INN = a.INN,
                KPP = a.KPP,
            };
        }
    }
}
