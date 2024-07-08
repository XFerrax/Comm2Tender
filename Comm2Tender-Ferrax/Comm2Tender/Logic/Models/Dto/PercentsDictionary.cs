using System;

namespace Comm2Tender.Logic.Models.Dto
{
    public class PercentsDictionary
    {
        public int PercentsDictionaryId { get; set; } // int
        public DateTime DateEnter { get; set; } // datetime
        public decimal RefinancingRate { get; set; } // decimal(4, 3)
        public decimal Tmk { get; set; } // decimal(4, 3)
        public decimal BankGuarantee { get; set; } // decimal(4, 3)
        public decimal Credit { get; set; } // decimal(4, 3)
        public decimal CustomDuty { get; set; } // decimal(4, 3)
        public decimal Discount { get; set; } // decimal(4, 3)


        public static implicit operator PercentsDictionary(Data.PercentsDictionary a)
        {
            if (a == null) return null;

            return new PercentsDictionary()
            {
                PercentsDictionaryId = a.PercentsDictionaryId,
                DateEnter = a.DateEnter,
                RefinancingRate = a.RefinancingRate,
                Tmk = a.Tmk,
                BankGuarantee = a.BankGuarantee,
                Credit = a.Credit,
                CustomDuty = a.CustomDuty,
                Discount = a.Discount,
            };
        }

        public static implicit operator Data.PercentsDictionary(PercentsDictionary a)
        {
            if (a == null) return null;

            return new Data.PercentsDictionary()
            {
                PercentsDictionaryId = a.PercentsDictionaryId,
                DateEnter = a.DateEnter,
                RefinancingRate = a.RefinancingRate,
                Tmk = a.Tmk,
                BankGuarantee = a.BankGuarantee,
                Credit = a.Credit,
                CustomDuty = a.CustomDuty,
                Discount = a.Discount,
            };
        }
    }
}
