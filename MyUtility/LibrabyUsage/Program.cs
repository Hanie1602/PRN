using BmiV2;

namespace LibrabyUsage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bmi = BmiCalculator.GetBmi(40, 1.62);
            Console.WriteLine(bmi);
            Console.WriteLine("BMI: " + BmiCalculator.GetBmi(40, 1.62));
            Console.WriteLine("BMI: {0}", bmi);
            Console.WriteLine($"BMI: {bmi}");
            Console.WriteLine($@"BMI: {bmi}");
            Console.WriteLine($"BMI: {BmiCalculator.GetBmi(40, 1.62)}");


        }
    }
}
