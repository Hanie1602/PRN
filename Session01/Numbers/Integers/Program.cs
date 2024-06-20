namespace Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sum odds from 1..10: " + SumOddNumbers());

        }

        //CHALLENGE #6
        //SQL: SELECT SUM, COUNT, AVERAGE....
        //  FROM...
        //  WHERE...
        //  GROUP BY...
        //  HAVING....
        //Lỡ 1 lần đi qua tập Data, tính luôn nhiều giá trị!!!
        //Kẹt: Hàm trong Java, C, C# nói chung chỉ trả về 1 giá trị
        //Có cách nào để giúp hàm trả về nhiêu giá trị khi chỉ gọi hàm 1 lần, giống SELECT gộp nhiều hàm
        //CÓ: UT, VÀ REF



        //============================================================================
        //CHALLENGE #5: VIẾT HÀM TÍNH TỔNG TẤT CẢ CÁC SỐ LẺ TỪ 1..10
        //EXPECTED VALUE: 1 3 5 7 9 = 25
        //Actual        : ???? Chờ chạy hàm cái đã
        static int SumOddNumbers()
        {
            var sum = 0;
            for (int i = 0; i <= 10; i++)
            {
                if (i % 2 != 0)
                    //sum = sum + i
                    sum += i;
            }
            return sum;
        }

        //static void Main(string[] args)
        //{
        //    //PrintIntegerList();
        //    //PrintEvenNumbers();
        //    //PrintNumbersFrom1ToN(100000);
        //    var result = SumEvents();

        //    Console.WriteLine("Sum evens from 1..10: " + result);   //ghép chuỗi concatenation
        //    Console.WriteLine("Sum evens from 1..10: {0}", result);
        //    Console.WriteLine($"Sum evens from 1..10: {result}");
        //    Console.WriteLine(@$"Sum evens from 1..10: {result}");
        //    Console.WriteLine($"Sum evens from 1..10: {SumEvents()}");
        //    Console.WriteLine(@$"Căn bậc 2 của 100: {Math.Sqrt(100)}");

        //    string msg = @$"Căn bậc 2 của 100: {Math.Sqrt(100)}";
        //    Console.WriteLine(msg);
        //}


        //============================================================================
        //CHALLENGE #4: VIẾT HÀM TÍNH TỔNG CỦA CÁC SỐ CHẴN TỪ 1...10 (100)
        //2 4 6 8 10 => 30! HÀM VIẾT RA SAO KOC ẦN BIẾT, CHỈ CẦN BIẾT RẰNG NÓ PHẢI TRẢ VỀ HOẶC IN RA 30 - EXPEECTED VALUE: HY VỌNG HÀM TRẢ VỀ 30 - EXPECTED VALUE
        //Còn thực tế lúc chạy hàm  là bao nhiêu, ví dụ 40, 50, có khi 30, đoán xem, thì giá trị trả về của hàm được gọi là ACTUAL VALUE
        //Nếu ACTUAL == EXPECTED => Hàm ngon cho tình huống này!!!
        //UNIT TEST TRONG MÔN SET301
        static int SumEvents()
        {
            //int sum = 0;    //nhồi 1 2 3 4 5 6; nhồi 2 4 6 8 10
            var sum = 0;    //Java cũng có luôn
            //Kĩ thuật ko chỉ rõ tường minh data type của biến, mà data type của biến sẽ được suy luận từ giá trị gán vào, gán ngay lúc khai báo
            //type inferent: suy luận ngầm kiểu dataa của biến
            //Xài var bắt buộc phải gán giá trị khởi đầu
            for (int i = 1; i <= 10; i++)
                if (i % 2 == 0)
                    sum += i;   //Nếu trong for, if, else chỉ có 1 lệnh, bỏ { }
            
            return sum;
        }


        //============================================================================
        //CHALLENGE #3: VIẾT HÀM IN RA CÁC SỐ TỪ 1...ĐẾN N
        //Bữa sau: VAR, OUT, REF, OOP

        static void PrintNumbersFrom1ToN(in int n)
        {
            //n = 5000;
            //keyword ở tham số biến tham số thành read-only
            //để đảm bảo code luôn xử lý đúng tham số đầu vào!!!

            Console.WriteLine("The list of numbers from 1 to " + n);
            for (int i = 0; i <= n; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();    //Sống có trách nhiệm
        }

        //static void PrintNumbersFrom1ToN (int n)
        //{
        //    Console.WriteLine("The list of numbers from 1 to " + n);
        //    for (int i = 0; i <= n; i++)
        //    {
        //        Console.Write($"{i} " );
        //    }
        //    Console.WriteLine();    //Sống có trách nhiệm
        //}



        //============================================================================
        //CHALLENGE #2: VIẾT HÀM IN RA CÁC SỐ CHẲN TỪ 1...100
        static void PrintEvenNumbers()
        {
            Console.WriteLine("The list of even numbers from 1...100");
            for (int i = 1; i <= 100; i++) 
                if (i % 2 == 0)
                    Console.Write($"{i} ");

            Console.WriteLine();
        }



        //============================================================================
        //C# hỗ trợ các kiểu dữ liệu số nguyên y chang Java: int, long...
        //C# cũng hỗ trợ các cấu trúc câu lệnh y chang Java: if, if/else, switch, do-while, while
        //CHALLENGE #1: HÃY VIẾT 1 HÀM IN RA CÁC SỐ TỰ NHIÊN TỪ 1...100
        static void PrintIntegerList()
        {
            Console.WriteLine("The List of numbers from 1...100");
            //Console.WriteLine("1 2 3 4 5 6 7 8 9 10 11 12 13 14");
            for (int i = 1; i <= 100; i++)
            {
                //Console.Write(i + " ");
                //Console.Write("{0} ", i);
                Console.Write($"{i} ");
            }
            Console.WriteLine();    //Sống có trách nhiệm, in xong phải xuống hàng, tránh ảnh hưởng hàm sau đó
        }
    }
}

//CHALLENGE AT HOME
//KETWORD "IN" biến tham số đầu vào của hàm thành read-only, và nó có thể áp dụng cho biến primitve và biến object, hay gọi là áp dụng cho truyền tham trị và tham chiếu
//In nó biến tham số thành readonly, tức là ko cho thay đổi giá trị truyền vào hàm

//Vậy hàm F(in int n) thì n ko cho đổi value
//Vậy hàm F(in Student x) thì x readonly cỡ nào, đc thay đổi và ko thay đổi cụ thể thế nào?
//x là Student, nó phức tạp hơn int x
