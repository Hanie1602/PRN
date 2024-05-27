using StudentManagerV1.Entities;

namespace StudentManagerV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tạo mới hồ  sơ sinh viên, 1 bạn cụ thể nào đó
            Student s1 = new Student("SE1", "An", 2004, 8.6);
            //      biến        object, con người cụ thể
            //     Tên gọi      đc gọi tắt là s1 và hắn là Student
            s1.ShowProfile();

            string msg = s1.ToString();
            Console.WriteLine("s1 details: " + msg);
            Console.WriteLine("s1 details: " + s1.ToString());
            Console.WriteLine("s1 details: " + s1); //Gọi thầm tên em ToString() y chang bên Java
            Console.WriteLine("");

            //NẾU GHÉP TÊN BIẾN VÀO CHUỖI, THÌ BIẾN OBJECT SẼ TỰ ĐỘNG ĐI GỌI HÀM TOSTRING() ĐỂ LẤY CHUỖI BÊN TRONG OBJECT ĐEM ĐI GHÉP

            //Điều gì xảy ra nếu ta ko thêm làm hàm ToString()

            //CÁCH TẠO OBJECT #2
            Student s2 = new ("SE2", "Binh", 2004, 8.7);    //Sau new ko cần tên class vẫn giữ ý nhĩa gốc do khai báo là Student rồi
            s2.ShowProfile();
            Console.WriteLine(s2);  //Gọi thầm ToString()
            Console.WriteLine("");

            //CÁCH #3
            var s3 = new Student("SE3", "Cường", 2004, 8.8);
            s3.ShowProfile();   //type inferent
            Console.WriteLine("");

            //CÁCH #4
            var s4 = s3;    //2 chàng trỏ 1 nàng
            //Ko có từ khóa new, tức là ko có vùng RAM được cấp!!!
            Console.WriteLine("s4 check var!!!!!");
            s4.ShowProfile();
            Console.WriteLine("");

            s4.SetGpa(999);
            Console.WriteLine("c3 check var after c4 modification");
            s3.ShowProfile();

            //Lưu ý nếu bạn có 1 hàm nhận vào biến object
            //void F(Student x)
            //{
            //}
            //Gọi hàm: F(s4) ~~~~ x = s4 trong hàm
            //Trong thân hàm, x làm gì, thì  ngoài hàm lãnh đủ
            //Do đó hàm nhận vào biến object chính là đã truyền tham chiếu luôn rồi!!!! Do trong hàm và ngoài hàm cùng trỏ 1 vùng RAM new bự chà bá.
        }
    }
}
