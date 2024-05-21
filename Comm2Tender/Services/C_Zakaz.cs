namespace Comm2Tender.Services
{
    public class C_Zakaz : IC_Zakaz
    {
        public C_Zakaz(int countToVar, float amount1, float amountDelivery)
        {
            Value = (countToVar * amount1) + amountDelivery;
        }

        public double Value { get; private set; }
    }
}
