namespace Comm2Tender.Logic.Models.Dto
{
    public class CustomFeeDictionary
    {
        public int CustomFeeDictionaryId { get; set; } // int
        public decimal MinAmount { get; set; } // decimal(13, 3)
        public decimal SummaryCustomFee { get; set; } // decimal(11, 3)


        public static implicit operator CustomFeeDictionary(Data.CustomFeeDictionary a)
        {
            if (a == null) return null;

            return new CustomFeeDictionary()
            {
                CustomFeeDictionaryId = a.CustomFeeDictionaryId,
                MinAmount = a.MinAmount,
                SummaryCustomFee = a.SummaryCustomFee,
            };
        }

        public static implicit operator Data.CustomFeeDictionary(CustomFeeDictionary a)
        {
            if (a == null) return null;

            return new Data.CustomFeeDictionary()
            {
                CustomFeeDictionaryId = a.CustomFeeDictionaryId,
                MinAmount = a.MinAmount,
                SummaryCustomFee = a.SummaryCustomFee,
            };
        }
    }
}
