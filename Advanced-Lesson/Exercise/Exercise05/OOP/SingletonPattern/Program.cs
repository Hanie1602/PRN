using System.Runtime.CompilerServices;

namespace SingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(DemoClass.Run);
            Thread t2 = new Thread(DemoClass.Run);
            t1.Start();
            t2.Start();
            Console.WriteLine("Finish");
        }
    }
}
