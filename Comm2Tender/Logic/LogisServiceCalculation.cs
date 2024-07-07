using Comm2Tender.Logic.Models;
using Comm2Tender.Logic.Models.Dto;
using System.Collections.Generic;

namespace Comm2Tender.Logic
{
    public partial class LogicService : ILogicServiceCalculation
    {
        public ListResponse Calculate(int tenderId)
        {
            var calculations = new List<Calculation>();

            var proposals = DataService.GetProposalsByTenderId(tenderId);
            var persentsDictionary = DataService.GetLastPercentsDictionary();

            foreach ( var proposal in proposals )
            {
                try
                {
                    var customFee = DataService.GetCustomFeeByPositionPrice(proposal.PositionPrice);
                    var calcOrder = new CalcOrder(proposal);
                    var economyEffect = new CalcEconomyEffect(calcOrder, proposal, persentsDictionary, customFee);
                    var reliabilityAssessments = new CalcReliabilityAssessment(calcOrder, proposal, persentsDictionary);

                    var calculation = new Calculation();
                    calculation.AgentName = proposal.Agent.Name;
                    calculation.ProposalId = proposal.ProposalId;
                    calculation.PositionPrice = proposal.PositionPrice;
                    calculation.EconomyEffect = economyEffect.Value;
                    calculation.ReliabilityAssessment = reliabilityAssessments.Value;
                    calculation.IntegralAssessment = proposal.PositionPrice - economyEffect.Value - reliabilityAssessments.Value;

                    calculations.Add(calculation);
                }
                catch (System.Exception ex)
                {
                    var calculation = new Calculation();
                    calculation.AgentName = proposal.Agent.Name;
                    calculation.PositionPrice = proposal.PositionPrice;
                    calculation.Note = ex.Message;

                    calculations.Add(calculation);
                }
            }

            var listResponce = new ListResponse();
            listResponce.Items = calculations;
            listResponce.Total = calculations.Count;

            return listResponce;
        }
    }
}
