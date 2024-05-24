namespace IntegersRef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 6868;

            ChangeX(ref x);

            Console.WriteLine(x);
        }

        static void ChangeX(ref int p)
        {
            p = 6789;
        }
    }
}


//IN OU REF: 3 THẰNG KU NÀY DÍNH ĐẾN THAM SỐ ĐẦU VÀO
//OUT VÀ REF GIỐNG NHAU 99%
//TRONG HÀM THAY ĐỔI, BÊN NGOÀI BỊ ĐỔI THEO - TRUYỀN THAM CHIẾU - PASS BY REFERENCE
//OUT: hứa chắc kèo, chắc chắn có 1 giá trị trả về trong hàm
//REF: ko hứa có thể có, có thể ko
//     Xài REF bắt buộc phải gán value cho biến trước phòng hờ REF ko làm gì cả
//     Sau gọi hàm vẫn có value!!!

//NHA SĨ KHUYÊN DÙNG - CHỐT HẠ:
//Dùng out tiện lợi hơn, tự nhiên hơn, do luôn hứa trả về giá trị, koc ần giá trị khởi đầu cho biến hứng value
//Hàm luôn phải trả value thì mới hợp logic
//CLASS
//GENERIC <>
// ĐI VÀO DELEGATE -> ANONYMOUS METHOD -> LAMBDA EXPRESSION -> LINO -> EF CORE DE

//ĐI VÀO PE