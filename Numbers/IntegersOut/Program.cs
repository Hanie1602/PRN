namespace IntegersOut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Xài hàm out ra sao????
            //Có 3 cách
            //C1: Khai báo biến và gắn sẵn value, nhưng value sẽ bị đè, sửa bởi bên trong hàm.
            int n = 3979;
            Console.WriteLine("Before calling out method, n = " + n);
            ChangeXV2(out n);
            Console.WriteLine("After calling out method, n = " + n);
            Console.WriteLine("");

            //C2: Khai báo biến, ko thèm gán value cho biến vì đằng nào hàm out đã hứa sẽ có value
            int x;
            //Console.WriteLine("Before calling out method, x = " + x);
            ChangeXV2(out x);
            Console.WriteLine("After calling out method, x = " + x);
            Console.WriteLine("");

            //C3: Cách này ChatGPT, Copilot hay dùng!!!
            //Vừa khai báo biến, vừa truyền vào out, đằng nào cũng được value từ hàm ném ra!!!
            ChangeXV2(out int xxx);
            Console.WriteLine("After calling out method, xxx = " + xxx);
        }

        //Xài hàm cần biến đưa vào
        //      int xxx = 20;
        //      ChangeXV2(out xxx)
        static void ChangeXV2(out int p)
        {
            //Chữ out: hứa, trong hàm sẽ có 1 value cho n!!! phải gán 1 giá trị cho n; ko báo lỗi - giữ lời hứa luôn có value nào đó  !!!!
            p = 6789;   //sbtc      2204 mãi mãi ko chet


        }









        //static void Main(string[] args)
        //{
        //    int x = 10;
        //    ChangeXV1(x);   //Gọi hàm để xem biến có đổi ko??
        //    Console.WriteLine("After calling method, x = " + x);
        //}

        //Viết 1 hàm nhận vào 1 con số (Qua biến đầu vào), sau đó hàm thay đổi biến đầu này thành giá trị mới
        //kỸ THUẬT TRUYỀN THỐNG: TRUYỀN THAM TRỊ, PASS BY VALUE
        // COPY DATA TỪ VỊ TRÍ GỐ SÁNG HÀM ĐƯỢC GỌI
        //HÀM LÀM GÌ KO BIÊT, DATA GỐC KO BỊ THAY ĐỔI
        //PASS BY VALUE: T CHO M BẢN COPY DATA, Photo ra 1 bản

        static void ChangeXV1(int n)
        {
            Console.WriteLine("In method, n at first: " + n);
            n = 3979;
            Console.WriteLine("In method, n at second: " + n);
        }

    }
}
