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
        public OptionCalculation(int _stockPrice, int _strikePrice, int _riskFreeIntrestRate, int _timeToMaturity, int _standardDeviation)
        {
            stockPrice = _stockPrice;
            strikePrice = _strikePrice;
            riskFreeIntrestRate = _riskFreeIntrestRate;
            timeToMaturity = _timeToMaturity;
            standardDeviation = _standardDeviation;
        }

        private double D_1()
        {
            var d1 = (Math.Log(stockPrice / strikePrice) + (riskFreeIntrestRate + (Math.Pow(standardDeviation, 2)) / 2) * timeToMaturity)/(standardDeviation*Math.Sqrt(timeToMaturity));
            return d1;
        }

        private double D_2(double d1)
        {
            var d2 = d1 - standardDeviation * Math.Sqrt(timeToMaturity);
            return d2;
        }

        private double CallOptionPremiums()
        {
            normalDistributionResultOfD1 = Normal.CDF(1, 0, D_1());

            D_1();

            exponentalResultRiskFreeIntrestRateResult = Exponential.CDF(riskFreeIntrestRate, timeToMaturity);
            normalDistributionResultOfD2 = Normal.CDF(1, 0, D_2(D_1()));

            var callOptionPremiumsResult = standardDeviation * normalDistributionResultOfD1 - strikePrice * exponentalResultRiskFreeIntrestRateResult * normalDistributionResultOfD2;
            
            return callOptionPremiumsResult;
        }

        private double OptionPrice()
        {
            var optionPriceResult = strikePrice * exponentalResultRiskFreeIntrestRateResult * normalDistributionResultOfD2 - standardDeviation* normalDistributionResultOfD1;
            return optionPriceResult;
        }



    }
}
