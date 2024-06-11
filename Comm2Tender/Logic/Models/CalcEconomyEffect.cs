using Comm2Tender.Data;
using Comm2Tender.Models;
using Comm2Tender.Services;
using System;

namespace Comm2Tender.Logic.Models
{
    public class CalcEconomyEffect
    {
        public CalcEconomyEffect(
            CalcOrder order, 
            Proposal proposal, 
            PercentsDictionary percentsDictionary, 
            CustomFeeDictionary customFeeDictionary)
        {
            decimal oldCashflowink = 0, oldcashflowdiscontink = 0;
            int p = 0;
            for (int i = 5; i <= 730; i = i + 5)
            {
                decimal pay1 = 0, pay2 = 0, pay3 = 0;
                if (i == (proposal.DeliveryTime - proposal.PeriodOfExecution1 + 5))
                {
                    pay1 = order.Value * proposal.PrepaidExpense1 / 100;
                }
                if (i == (proposal.DeliveryTime - proposal.PeriodOfExecution2 + 5))
                {
                    pay2 = order.Value * proposal.PrepaidExpense2 / 100;
                }
                if (i == (proposal.DeliveryTime - proposal.PeriodOfExecution3 + 5))
                {
                    pay3 = order.Value * proposal.PrepaidExpense3 / 100;
                }

                int intPay1 = pay1 < 0 ? 1 : 0,
                    intPay2 = pay2 < 0 ? 1 : 0,
                intPay3 = pay3 < 0 ? 1 : 0;
                decimal post = i == proposal.DeliveryTime ? order.Value : 0;

                int intPay4 = post > 0 ? 1 : 0;

                decimal rateProc1 = 0, rateProc2 = 0, rateProc3 = 0;
                if (intPay1 == 1 && intPay4 == 0)
                {
                    rateProc1 = order.Value * proposal.PrepaidExpense1 * (percentsDictionary.RefinancingRate + percentsDictionary.Tmk) * 5 / 365;
                }
                if (intPay2 == 1 && intPay4 == 0)
                {
                    rateProc2 = order.Value * proposal.PrepaidExpense2 * (percentsDictionary.RefinancingRate + percentsDictionary.Tmk) * 5 / 365;
                }
                if (intPay3 == 1 && intPay4 == 0)
                {
                    rateProc3 = order.Value * proposal.PrepaidExpense3 * (percentsDictionary.RefinancingRate + percentsDictionary.Tmk) * 5 / 365;
                }

                decimal pay = pay1 + pay2 + pay3 + rateProc1 + rateProc2 + rateProc3;
                decimal postPay1 = 0, postPay2 = 0, postPay3 = 0;
                if (i == (proposal.DeliveryTime + proposal.PostPaymantPeriod1))
                {
                    postPay1 = order.Value * proposal.PostPaymant1 / 100;
                }
                if (i == (proposal.DeliveryTime + proposal.PostPaymantPeriod2))
                {
                    postPay2 = order.Value * proposal.PostPaymant2 / 100;
                }
                if (i == (proposal.DeliveryTime + proposal.PostPaymantPeriod3))
                {
                    postPay3 = order.Value * proposal.PostPaymant3 / 100;
                }

                decimal pospay = postPay1 + postPay2 + postPay3;

                decimal payacc = 0;
                if (proposal.Accreditive && post > 0)
                {
                    payacc = order.Value
                    * (proposal.PostPaymant1 + proposal.PostPaymant2 + proposal.PostPaymant3)
                    * percentsDictionary.Credit / 100;
                }

                decimal payposh = 0;
                if (proposal.CustomDuty && post > 0)
                {
                    payposh = order.Value * percentsDictionary.CustomDuty;
                }

                decimal paysbor = 0;
                if (proposal.CustomFee && post == 0)
                {
                    paysbor = 0;
                }
                else
                {
                    paysbor = customFeeDictionary.SummaryCustomFee;
                }

                decimal totalloss = pay + pospay + payacc + payposh + paysbor;

                int intPay5 = post > 0 ? 1 : 0,
                    intPay6 = postPay1 < 0 ? 1 : 0,
                    intPay7 = postPay2 < 0 ? 1 : 0,
                    intPay8 = postPay3 < 0 ? 1 : 0;
                decimal profit1 = 0, profit2 = 0, profit3 = 0;
                if (intPay5 == 1 && intPay6 == 0)
                {
                    profit1 = order.Value * proposal.PostPaymant1 * 5 * (percentsDictionary.RefinancingRate + percentsDictionary.Tmk) / 365;
                }
                if (intPay5 == 1 && intPay7 == 0)
                {
                    profit2 = order.Value * proposal.PostPaymant2 * 5 * (percentsDictionary.RefinancingRate + percentsDictionary.Tmk) / 365;
                }
                if (intPay5 == 1 && intPay8 == 0)
                {
                    profit3 = order.Value * proposal.PostPaymant3 * 5 * (percentsDictionary.RefinancingRate + percentsDictionary.Tmk) / 365;
                }

                decimal paygarant = 0;
                if (proposal.BankGuarantee && i == 5)
                {
                    paygarant = order.Value * percentsDictionary.BankGuarantee
                    * (proposal.PrepaidExpense1 + proposal.PrepaidExpense2 + proposal.PrepaidExpense3)
                    / 100;
                }
                decimal totalprofit = post + profit1 + profit2 + profit3 + paygarant;
                decimal cashflow = totalloss + totalprofit,
                    cashflowink = cashflow + oldCashflowink,
                    discountraid = Convert.ToDecimal(Math.Pow(Convert.ToDouble(1 / (1 + (percentsDictionary.RefinancingRate + percentsDictionary.Tmk) / 73)), p)),
                    cashflowdiscont = cashflow * discountraid,
                    cashflowdiscontink = cashflowdiscont + oldcashflowdiscontink;

                oldCashflowink = cashflowink;
                oldcashflowdiscontink = cashflowdiscontink;
                p++;
            }
            Value = oldcashflowdiscontink;
        }

        public decimal Value { get; private set; }
    }
}
