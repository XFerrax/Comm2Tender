using Comm2Tender.Logic.Models;
using Comm2Tender.Logic.Models.Dto;
namespace Comm2TenderTests
{
    [TestClass]
    public class UnitTestCalcOrder
    {
        Proposal Proposal { get; set; }
        CalcOrder CalcOrder { get; set; }
        PercentsDictionary PercentsDictionary { get; set; }
        CustomFeeDictionary CustomFeeDictionary { get; set; }
        [TestInitialize]
        public void UnitTestInitialize()
        {
            Proposal = new Proposal()
            {
                ProposalId = 1,
                PositionPrice = 5250000,
                CountPos = 1,
                DeliveryCost = 0,
                DeliveryTime = 20,
                PrepaidExpense1 = 0.2m,
                PrepaidExpense2 = 0.05m,
                PrepaidExpense3 = 0,
                PeriodOfExecution1 = 5,
                PeriodOfExecution2 = 5,
                PeriodOfExecution3 = 0,
                PostPaymant1 = 0.75m,
                PostPaymant2 = 0,
                PostPaymant3 = 0,
                PostPaymantPeriod1 = 5,
                PostPaymantPeriod2 = 0,
                PostPaymantPeriod3 = 0,
                Accreditive = true,
                BankGuarantee = false,
                CustomDuty = false,
                CustomFee = false,
                MissingDeadlines = false,
                PoorQuality = false,
                NormsViolated = false,
                Agent = new Agent(),
                /* ... */
            };
            PercentsDictionary = new PercentsDictionary()
            {
                PercentsDictionaryId = 1,
                BankGuarantee = 0.02m,
                RefinancingRate = 0.12m,
                Credit = 0.01m,
                CustomDuty = 0.1m,
                Tmk = 0.02m,
                Discount = 0.12m,
                DateEnter = DateTime.Now,
            };
            CustomFeeDictionary = new CustomFeeDictionary()
            {
                CustomFeeDictionaryId = 1,
                SummaryCustomFee = 20000,
                MinAmount = 1000000,
            };
            CalcOrder = new CalcOrder(Proposal);
        }
        [TestMethod]
        public void TestCalcOrder()
        {
            Assert.AreEqual(5250000M, CalcOrder.Value);
        }
        [TestMethod]
        public void TestCalcReliabilityAssessment()
        {
            var calcReliabilityAssessment = new CalcReliabilityAssessment(CalcOrder, Proposal, PercentsDictionary);
            Assert.AreEqual(546_875M, Math.Round(calcReliabilityAssessment.Value, 0));
        }
        [TestMethod]
        public void TestCalcEconomyEffect()
        {
            var calcEconomyEffect = new CalcEconomyEffect(CalcOrder, Proposal, PercentsDictionary, CustomFeeDictionary);
            Assert.AreEqual(-26_165M, Math.Round(calcEconomyEffect.Value));
        }
    }
}