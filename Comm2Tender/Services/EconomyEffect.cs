using Comm2Tender.Models;
using Comm2Tender.Repositories;
using System;

namespace Comm2Tender.Services
{
    public class EconomyEffect
    {
        public EconomyEffect(
            IC_Zakaz zakaz,
            InterestRate interest,
            СustomsDuty сustomsDuty, 
            EconomicEffectVar economicEffectVar,
            VarContragentOfTender varContragentOfTender,
            double sumCustom
            )
        {

            double oldCashflowink = 0, oldcashflowdiscontink = 0;
            int p = 1;
            for (int i = 0; i <= 730; i = i + 5)
            {
                double pay1 = 0, pay2 = 0, pay3 = 0;
                if (i == (varContragentOfTender.CountDayDelivery - economicEffectVar.PeriodOfExecution + 5))
                {
                    pay1 = zakaz.Value * economicEffectVar.PrepaidExpense ?? 0 / 100;
                }
                if (i == (varContragentOfTender.CountDayDelivery - economicEffectVar.PeriodOfExecution2 + 5))
                {
                    pay2 = zakaz.Value * economicEffectVar.PrepaidExpense2 ?? 0 / 100;
                }
                if (i == (varContragentOfTender.CountDayDelivery - economicEffectVar.PeriodOfExecution3 + 5))
                {
                    pay3 = zakaz.Value * economicEffectVar.PrepaidExpense3 ?? 0 / 100;
                }

                int intPay1 = pay1 < 0 ? 1 : 0,
                    intPay2 = pay2 < 0 ? 1 : 0,
                    intPay3 = pay3 < 0 ? 1 : 0;

                double post = i == varContragentOfTender.CountDayDelivery ? zakaz.Value : 0;

                int intPay4 = post > 0 ? 1 : 0;

                double rateProc1 = 0, rateProc2 = 0, rateProc3 = 0;
                if (intPay1 == 1 && intPay4 == 0)
                {
                    rateProc1 = zakaz.Value * economicEffectVar.PrepaidExpense ?? 0 * (interest.RateCb ?? 0 + interest.PersTmk ?? 0) * 5 / 365;
                }

                if (intPay2 == 1 && intPay4 == 0)
                {
                    rateProc2 = zakaz.Value * economicEffectVar.PrepaidExpense2 ?? 0 * (interest.RateCb ?? 0 + interest.PersTmk ?? 0) * 5 / 365;
                }

                if (intPay3 == 1 && intPay4 == 0)
                {
                    rateProc3 = zakaz.Value * economicEffectVar.PrepaidExpense3 ?? 0 * (interest.RateCb ?? 0 + interest.PersTmk ?? 0) * 5 / 365;
                }

                double pay = pay1 + pay2 + pay3 + rateProc1 + rateProc2 + rateProc3;
                double postPay1 = 0, postPay2 = 0, postPay3 = 0;
                if (i == (varContragentOfTender.CountDayDelivery + economicEffectVar.PostpaymentPeriod))
                {
                    postPay1 = zakaz.Value * economicEffectVar.Postpayment ?? 0 / 100;
                }
                if (i == (varContragentOfTender.CountDayDelivery + economicEffectVar.PostpaymentPeriod2))
                {
                    postPay2 = zakaz.Value * economicEffectVar.Postpayment2 ?? 0 / 100;
                }
                if (i == (varContragentOfTender.CountDayDelivery + economicEffectVar.PostpaymentPeriod3))
                {
                    postPay3 = zakaz.Value * economicEffectVar.Postpayment3 ?? 0 / 100;
                }

                double pospay = postPay1 + postPay2 + postPay3;

                double payacc = 0;
                if (economicEffectVar.IsAccredetive ?? false && post > 0)
                {
                    payacc = zakaz.Value
                        * (economicEffectVar.Postpayment ?? 0 + economicEffectVar.Postpayment2 ?? 0 + economicEffectVar.Postpayment3 ?? 0)
                        * interest.PersBillOfCreadit ?? 0 / 100;
                }

                double payposh = 0;
                if(economicEffectVar.IsCustomsDuty??false&& post > 0)
                {
                    payposh = zakaz.Value * interest.PersCustoms ?? 0;
                }

                double paysbor = sumCustom;
                if (economicEffectVar.IsCustomsFee ?? false && post == 0)
                {
                    paysbor = 0;
                }

                double totalloss = pay + pospay + payacc + payposh + paysbor;

                int intPay5 = post > 0?1:0, 
                    intPay6 = postPay1 < 0?1:0, 
                    intPay7 = postPay2 < 0 ? 1 : 0, 
                    intPay8 = postPay3 < 0 ? 1 : 0;
                double profit1 = 0, profit2 = 0, profit3 = 0;
                if (intPay5 == 1&& intPay6==0)
                {
                    profit1 = zakaz.Value * economicEffectVar.Postpayment ?? 0 * 5 * (interest.RateCb ?? 0 + interest.PersTmk ?? 0) / 365;
                }
                if (intPay5 == 1 && intPay7 == 0)
                {
                    profit2 = zakaz.Value * economicEffectVar.Postpayment2 ?? 0 * 5 * (interest.RateCb ?? 0 + interest.PersTmk ?? 0) / 365;
                }
                if (intPay5 == 1 && intPay8 == 0)
                {
                    profit3 = zakaz.Value * economicEffectVar.Postpayment3 ?? 0 * 5 * (interest.RateCb ?? 0 + interest.PersTmk ?? 0) / 365;
                }

                double paygarant = 0;
                if (economicEffectVar.IsBankGuarantee ?? false)
                {
                    paygarant = zakaz.Value * interest.PersBank ?? 0
                        * (economicEffectVar.PrepaidExpense ?? 0 + economicEffectVar.PrepaidExpense2 ?? 0 + economicEffectVar.PrepaidExpense3 ?? 0)
                        / 100;
                }

                double totalprofit = post + profit1 + profit2 + profit3 + paygarant;


                double cashflow = totalloss + totalprofit,
                    cashflowink = cashflow + oldCashflowink,
                    
                    discountraid = Math.Pow((1 / (1 + (interest.RateCb ?? 0 + interest.PersTmk ?? 0) / 73)), p),
                    cashflowdiscont = cashflow * discountraid,
                    cashflowdiscontink = cashflowdiscont+ oldcashflowdiscontink;

                oldCashflowink = cashflowink;
                oldcashflowdiscontink = cashflowdiscontink;
                p++;
            }
            Value = oldcashflowdiscontink;
        }

        public double Value { get; private set; }
    }
}
