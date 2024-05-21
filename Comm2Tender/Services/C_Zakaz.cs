namespace Comm2Tender.Services
{
    public class C_Zakaz : IC_Zakaz
    {
        public C_Zakaz(int countTovar, float Amount1, float AmountDelivery)
        {
            Value = (countTovar * Amount1) + AmountDelivery;
        }

        public float Value { get; private set; }
    }
}
