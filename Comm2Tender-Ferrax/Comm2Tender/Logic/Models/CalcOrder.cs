namespace Comm2Tender.Logic.Models
{
    public class CalcOrder
    {
        public CalcOrder(Dto.Proposal proposal)
        {
            Value = (proposal.CountPos * proposal.PositionPrice) + proposal.DeliveryCost;
        }

        public decimal Value {  get; private set; }
    }
}
