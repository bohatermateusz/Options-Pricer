using System;
using MathNet.Numerics.Distributions;

namespace Options_Pricer
{
    internal class OptionCalculation
    {
        int stockPrice { get; set; }
        int strikePrice { get; set; }
        int riskFreeIntrestRate { get; set; }
        int timeToMaturity { get; set; }
        int standardDeviation { get; set; }
        double d1 { get; set; }
        double d2 { get; set; }
        double exponentalResultRiskFreeIntrestRateResult { get; set; }
        internal OptionCalculation(int _stockPrice, int _strikePrice, int _timeToMaturity, int _standardDeviation, int _riskFreeIntrestRate)
        {
            stockPrice = _stockPrice;
            strikePrice = _strikePrice;
            riskFreeIntrestRate = _riskFreeIntrestRate;
            timeToMaturity = _timeToMaturity;
            standardDeviation = _standardDeviation;

            Variable_Calculations();
        }
        internal double CallOptionPremiums()
        {
            var callOptionPremiumsResult = standardDeviation * Normal.CDF(1, 0, d1) - strikePrice * exponentalResultRiskFreeIntrestRateResult * Normal.CDF(1, 0, d2);   
            return callOptionPremiumsResult;
        }
        internal double OptionPrice()
        {
            var optionPriceResult = strikePrice * exponentalResultRiskFreeIntrestRateResult * Normal.CDF(1, 0, - d2) - standardDeviation* Normal.CDF(1, 0, - d1);
            return optionPriceResult;
        }
        private void Variable_Calculations()
        {
            d1 = (Math.Log(stockPrice / strikePrice) + (riskFreeIntrestRate + (Math.Pow(standardDeviation, 2)) / 2) * timeToMaturity) / (standardDeviation * Math.Sqrt(timeToMaturity));
            d2 = d1 - standardDeviation * Math.Sqrt(timeToMaturity);
            exponentalResultRiskFreeIntrestRateResult = Exponential.CDF(riskFreeIntrestRate, timeToMaturity);
        }

        internal double NormalDistributionResult(double x)
        {
            var result = Normal.CDF(1, 0, x);
            return result;
        }
    }
}
