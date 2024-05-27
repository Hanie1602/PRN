using StudentManagerV2.Entities;

namespace StudentManagerV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tạo object khi cái khuôn có đến 2 cái phễu
            Student s1 = new("SE1", "An", 2004, 8.6);
            Console.WriteLine("s1 details: " + s1); //Gọi thầm tên em ToString()


            Student s2 = new("SE2", "Binh");
            Console.WriteLine("s2 detail: " + s2);
            //Nếu biến cục bộ (Biến khai báo trong hàm) mà ko gán giá trị
            //Thì cấm sử dụng ở các lệnh tiếp đó
            //Nếu field của object mà ko dc gán value lúc đúc, lúc new
            //Thì sẽ mang giá trị default
            //Số = 0, chữ = rỗng, bool thì là false
            //Để đảm bảo các hàm bên trong object vẫn sử dụng biến đc bình thường, vì đã có value, dù là value default

            //Để sửa được những value default này thì ta đổ value mới cho nó, tức là gọi hàm SETTER(Đưa vào data mới đè data cũ)
            s2.SetYob(2004);
            s2.SetYob(2005);
            s2.SetYob(2006);
            s2.SetYob(2007);
            Console.WriteLine("s2 after sorting yob: " + s2);   //Gọi thầm tên em

            //1 vùng new SE2 Binh có thể được chỉnh sửa INFO thoải mái số lần
            //Nghĩa là hàm SET() có quyền gọi nhiều lần và vẫn là object đó, vẫn là vùng new đó
            //Nhưng
            s2 = new Student("S22", "Hai Hai");
            Console.WriteLine("s2 after setting yob: " + s2);

            //Khi dùng new là lập tức có vùng RAM mới
            //New là gọi phễu để đúc ra object mới
            //.Set() có thể gọi n lần, ứng với việc mình thay đổi background thành hình bạn trai/bạn gái mới
            //Thay đổi background bao nhiêu lần thì vẫn là cái điện thoại cũ/object
            //Set() thay đổi trên objet
            //New tạo mới object hoàn toàn
        }
    }
}
