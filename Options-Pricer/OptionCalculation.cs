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
        double exponentalResultRiskFreeIntrestRateResult { get; set; }
        double normalDistributionResultOfD2 { get; set; }
        double normalDistributionResultOfD1 { get; set; }
        internal OptionCalculation(int _stockPrice, int _strikePrice, int _timeToMaturity, int _standardDeviation, int _riskFreeIntrestRate)
        {
            stockPrice = _stockPrice;
            strikePrice = _strikePrice;
            riskFreeIntrestRate = _riskFreeIntrestRate;
            timeToMaturity = _timeToMaturity;
            standardDeviation = _standardDeviation;

            Variable_Calculations();
        }
        private double D_1_Value()
        {
            var d1 = (Math.Log(stockPrice / strikePrice) + (riskFreeIntrestRate + (Math.Pow(standardDeviation, 2)) / 2) * timeToMaturity)/(standardDeviation*Math.Sqrt(timeToMaturity));
            return d1;
        }
        private double D_2_Value(double d1)
        {
            var d2 = d1 - standardDeviation * Math.Sqrt(timeToMaturity);
            return d2;
        }
        internal double CallOptionPremiums()
        {
            var callOptionPremiumsResult = standardDeviation * normalDistributionResultOfD1 - strikePrice * exponentalResultRiskFreeIntrestRateResult * normalDistributionResultOfD2;   
            return callOptionPremiumsResult;
        }
        internal double OptionPrice()
        {
            var optionPriceResult = strikePrice * exponentalResultRiskFreeIntrestRateResult * normalDistributionResultOfD2 - standardDeviation* normalDistributionResultOfD1;
            return optionPriceResult;
        }
        private void Variable_Calculations()
        {
            normalDistributionResultOfD1 = Normal.CDF(1, 0, D_1_Value());
            exponentalResultRiskFreeIntrestRateResult = Exponential.CDF(riskFreeIntrestRate, timeToMaturity);
            normalDistributionResultOfD2 = Normal.CDF(1, 0, D_2_Value(D_1_Value()));
        }
    }
}
