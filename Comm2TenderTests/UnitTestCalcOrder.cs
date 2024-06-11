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
                /* ... */
            };

            PercentsDictionary = new PercentsDictionary()
            {

            };

            CustomFeeDictionary = new CustomFeeDictionary()
            {
            
            };

            CalcOrder = new CalcOrder(Proposal);
        }

        [TestMethod]
        public void TestCalcOrder()
        {
            
            

            Assert.AreEqual(123M, CalcOrder.Value);
        }

        [TestMethod]
        public void TestCalcReliabilityAssessment()
        {

            var calcReliabilityAssessment = new CalcReliabilityAssessment(CalcOrder, Proposal, PercentsDictionary);

            Assert.AreEqual(123M, calcReliabilityAssessment.Value);
        }

        [TestMethod]
        public void TestCalcEconomyEffect()
        {

            var calcEconomyEffect = new CalcEconomyEffect(CalcOrder, Proposal, PercentsDictionary, CustomFeeDictionary);

            Assert.AreEqual(123M, calcEconomyEffect.Value);
        }
    }
}