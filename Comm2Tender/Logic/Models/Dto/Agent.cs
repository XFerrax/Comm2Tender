using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comm2Tender.Logic.Models.Dto
{
    public class Agent
    {
        public int AgentId { get; set; }
        public bool IsUseBalance { get; set; }
        public decimal Balance { get; set; }


        public static implicit operator Agent(Data.Agent a)
        {
            if (a == null) return null;

            return new Agent()
            {
                AgentId = a.AgentId,
            };
        }

        public static implicit operator Data.Agent(Agent a)
        {
            if (a == null) return null;

            return new Data.Agent()
            {
                AgentId = a.AgentId,
            };
        }
    }
}
