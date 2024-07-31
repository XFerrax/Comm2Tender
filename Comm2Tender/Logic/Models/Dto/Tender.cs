namespace Comm2Tender.Logic.Models.Dto
{
    public class Tender
    {
        public long TenderId { get; set; } // int
        public string Number { get; set; } // nvarchar(50)
        public string Discription { get; set; } // nvarchar(50)
        public PercentsDictionary PercentsDictionary { get; set; } // int
        public Proposal? WinnerProposal { get; set; } // int
        public int? WinnerProposalId { get; set; } // int


        public static implicit operator Tender(Data.Tender a)
        {
            if (a == null) return null;

            return new Tender()
            {
                TenderId = a.TenderId,
                Number = a.Number,
                Discription = a.Discription,
                PercentsDictionary = a.PercentsDictionary,
                WinnerProposal = a.WinnerProposal,
            };
        }

        public static implicit operator Data.Tender(Tender a)
        {
            if (a == null) return null;

            return new Data.Tender()
            {
                TenderId = a.TenderId,
                Number = a.Number,
                Discription = a.Discription,
                PercentsDictionaryId = a.PercentsDictionary.PercentsDictionaryId,
                WinnerProposalId = a.WinnerProposalId,
            };
        }
    }
}
