using System;
using System.Globalization;

namespace Options_Pricer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Please provide basic data for Option Calculus");
            Console.WriteLine("Please provide Stock price:");
            var s = double.Parse(Console.ReadLine());
            Console.WriteLine("Please provide Strike price:");
            var k = double.Parse(Console.ReadLine());
            Console.WriteLine("Please provide Time to maturity:");
            var t = double.Parse(Console.ReadLine());
            Console.WriteLine("Please provide Standard deviation of underlying stock:");
            var sd = double.Parse(Console.ReadLine());
            Console.WriteLine("Please provide Risk-free interest rate:");
            var r = double.Parse(Console.ReadLine());

            OptionCalculation instance = new OptionCalculation(s,k,t,sd,r);
            
            Console.WriteLine("Your Put Option Value is:");
            Console.WriteLine(instance.PutOption());

            Console.WriteLine("Your Call Option Value is:");
            Console.WriteLine(instance.CallOption());
            Console.ReadLine();
        }
    }
}
