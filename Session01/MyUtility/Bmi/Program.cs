namespace Bmi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double weight = 40;         //40kg
            double height = 1.62;        //m
            double bmi = weight / (height * height);

            Console.WriteLine($"Your bmi is {bmi}");
        }
    }
}
