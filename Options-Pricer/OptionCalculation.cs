using System;
using MathNet.Numerics.Distributions;

namespace Options_Pricer
{
    internal class OptionCalculation
    {
        double stockPrice { get; set; }
        double strikePrice { get; set; }
        double riskFreeIntrestRate { get; set; }
        double timeToMaturity { get; set; }
        double standardDeviation { get; set; }
        double d1 { get; set; }
        double d2 { get; set; }
        double exponentalResultRiskFreeIntrestRateResult { get; set; }
        internal OptionCalculation(double _stockPrice, double _strikePrice, double _timeToMaturity, double _standardDeviation, double _riskFreeIntrestRate)
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
            var callOptionPremiumsResult = stockPrice * Normal.CDF(0, 1, d1) - strikePrice * exponentalResultRiskFreeIntrestRateResult * Normal.CDF(0, 1, d2);   
            return callOptionPremiumsResult;
        }
        internal double OptionPrice()
        {
            var optionPriceResult = strikePrice * exponentalResultRiskFreeIntrestRateResult * Normal.CDF(0, 1, - d2) - stockPrice* Normal.CDF(0, 1, - d1);
            return optionPriceResult;
        }
        private void Variable_Calculations()
        {
            var log = (Math.Log(stockPrice / strikePrice));
            var pow = (Math.Pow(standardDeviation, 2));
            var sqrt = (Math.Sqrt(timeToMaturity));

            d1 = (Math.Log(stockPrice / strikePrice) + (riskFreeIntrestRate + (Math.Pow(standardDeviation, 2)) / 2) * timeToMaturity) / (standardDeviation * Math.Sqrt(timeToMaturity));
            d2 = d1 - standardDeviation * Math.Sqrt(timeToMaturity);
            exponentalResultRiskFreeIntrestRateResult = Exponential.PDF(1, timeToMaturity * riskFreeIntrestRate);
        }

        internal double NormalDistributionResult(double x)
        {
            var result = Normal.CDF(1, 0, x);
            return result;
        }
    }
}
