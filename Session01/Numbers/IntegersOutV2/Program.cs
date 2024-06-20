namespace IntegersOutV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Hàm trả về 6 món
            int sumA = ComputeNumbers(out int sumO, out int countO, out int sumE, out int countE, out int countP);
            Console.WriteLine("Sum all: " + sumA);
            Console.WriteLine("Sum odds: " + sumO);
            Console.WriteLine("Count odds: " + countO);
            Console.WriteLine("Sum evens: " + sumE);
            Console.WriteLine("Count evens: " + countE);
            Console.WriteLine("count primes: " + countP);
            Console.WriteLine($"101 co phai la so nguyen to: {IsPrime(101)}");


            //1...10    1 2 3 4 5 6 7 8 9 10    55
            //1 3 5 7 9                         25
            //2 4 6 8 10                        30
            //2 3  5 7                          4 tạm thời 0
            //
        }

        static bool IsPrime(int n)
        {
            //Viết code for đến căn bậc 2 tìm ước số
            //Nếu lỡ chia hết, false liền
            //Math.Sqrt() căn bậc 2
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;
            return true;
        }


        static int ComputeNumbers(out int sumOdds, out int countOdds, out int sumEvens, out int countEvens, out int countPrimes)
        {
            sumOdds = 0;
            countOdds = 0;
            sumEvens = 0;
            countEvens = 0;
            countPrimes = 0;
            int sumAll = 0;

            for (int i = 1; i <= 10; i++)
            {
                sumAll += i;        //sumAll = sumAll + i
                if (i % 2 == 0)     //Chẵn thì tổng chẵn, đếm chẵn
                { 
                    countEvens++;
                    sumEvens += i;
                }
                else
                {
                    countOdds++;
                    sumOdds += i;
                }

                //if (IsPrime(i) == true)
                //    countPrimes++;
                if (IsPrime(i)) 
                    countPrimes++;
            }
            return sumAll;
        }

        //CHALLENGE #1: VIẾT HÀM TRẢ VỀ
        //Tổng các số từ 1..10 (100)
        //Tổng các số lẽ từ 1..10
        //Tổng các số chẵn từ 1..10
        //Số lượng các số lẽ từ 1.10
        //Số lượng các số chẵn từ 1..10
        //Số lượng các số nguyên tố
        //...
        //Chỉ 1 hàm duy nhất!!!
    }
}
