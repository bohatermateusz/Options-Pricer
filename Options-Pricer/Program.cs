using System;

namespace Options_Pricer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Please provide basic data for Option Calculus");
            Console.WriteLine("Please provide Stock price:");
            var s = int.Parse(Console.ReadLine());
            Console.WriteLine("Please provide Strike price:");
            var k = int.Parse(Console.ReadLine());
            Console.WriteLine("Please provide Time to maturity:");
            var t = int.Parse(Console.ReadLine());
            Console.WriteLine("Please provide Standard deviation of underlying stock:");
            var sd = int.Parse(Console.ReadLine());
            Console.WriteLine("Please provide Risk-free interest rate:");
            var r = int.Parse(Console.ReadLine());
            
            OptionCalculation instance = new OptionCalculation(s,k,t,sd,r);
            
            Console.WriteLine(instance.CallOptionPremiums());
            Console.WriteLine(instance.OptionPrice());
        }
    }
}
