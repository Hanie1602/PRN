using StudentManagerV5.Entities;

namespace StudentManagerV5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            Console.WriteLine("s1 at first (default):");
            Console.WriteLine(s1);      //Gọi thầm tên em ToString()
            Console.WriteLine("");

            s1.SetName("An");
            s1.SetId("SE1");
            s1.SetYob(2004);
            Console.WriteLine("s1 after setting....):");
            Console.WriteLine(s1);
            Console.WriteLine("");

            //New đủ
            Student s2 = new("SE2", "Binh", 2004, 8.6);
            Console.WriteLine("s2 (full)");
            Console.WriteLine(s2);      //Gọi thầm tên em ToString()
            Console.WriteLine("");

            //New đủ nhưng.....
            var s3 = new Student(name: "Cuong", yob: 2005, gpa: 8.7, id: "SE3");
            //Kỹ thuật truyền value vào hàm, vào constructor nhưng ko theo thứ tự khai báo biến của tên hàm
            //Mà đảo thứ tự thoải mái value hàm thoải mái, miễn là ghi chú thêm tên biến đầu vào :
            //Giúp bạn truyền tham số theo cách bạn muốn, thứ tự bạn muốn mà ko gây báo lỗi tương thích tham số
            //Kỹ thuật này gọi là: Named Argument: truyền tham số
            //Đi kèm tên tham số

            //INSERT INTO ACCOUNT VAUE (THEO THỨ TỰ CỘT TRONG DB,....)
            //iNSERT iNTO ACCOUNT (EMAIL,PHONE, ID)   VALUES(...)

            //Object vô danh, Anonymous Object
            Student s4 = new("SE4", "Dung", 2004, 8.9);
            //   Tên biến     Object có full info
            //   Nick name
            // Con trỏ trỏ =  vùng new bự.
            //s4. tức là vào vùng new xem có gì, có public gì
            //s4 chính à tay cầm móc vào Con Diều vùng new
            new Student("SE4", "Dung", 2004, 8.9).ShowProfile();
            //Object được tạo ra nhưng ko bị biến nào trỏ vào
            //Như con diều bay lên rồi đứt dây, ko níu nó lại được để điều chỉnh
            //Object mà ko được đặt tên, gán biến trỏ, gọi là object vô danh Anonymous Object
            //Máy ảo Java, .NET RUNTIME định kì quét RAM coi có đứa nào
            //Trôi nổi, ko có con trỏ móc vào, thì bị Clear khỏi RAM
            // Đoạn CODE RUNTIME trong RAM dọn dẹp bộ nhớ gọi là
            //GARBAGE COLLECTOR - BỘ GOM RÁC - CTY MTĐT

            //Random rd = new Random();
            //double n = rd.NextDouble()    //0..1

            //double n = new Random().NextDouble();

            Student s5 = s2;      //SE2 |   Bình    |   8.6

            PassAStudent(s2);
            Console.WriteLine("");
            Console.WriteLine("s2 after calling method:");
            Console.WriteLine(s2);

        }

        //HÀM KHÁC NGOÀI MAIN() NHƯNG TRONG CLASS
        static void PassAStudent(Student x)     //PassX(int x)      PassX(out int x)
        {
            x.SetName("Thich Tu Do");
        }
    }
}
//TRUYỀN 1 OBJECT VÀO HÀM CHÍNH LÀ TRUEY62N VÙNG NEW BÊN NGOÀI VÀO HÀM
//Chính là truyền tham chiếu, vì trong hàm mà SET() gì thì vùng new bên ngoài bị ảnh hưởng ngay, hiện tượng 2 chàng trỏ 1 nàng
// Hàm nhận vào biến Object chính là truyền tham chiếu luôn rồi, trong hàm có thể thay đổi vùng new bên ngoài - ko cần REF OUT

//CÔNG THỨC ĐỂ LẬP TRÌNH OOP - OBJECT ORIENTED PARADIGM/PROGRAMING
//Lập trình dựa trên làm việc với các Object
//Objetc là gì???
//Object là những thứ cụ thể quanh ta, mà mô tả bằng những câu từ dài
//Mô tả qua 2 thứ, 2 góc nhìn
//Góc nhìn tĩnh - State - Về đặc điểm
//  ID, NAME, YOB, GPA, SALARY, WORKING, HOURS,...
//Góc nhìn động - Behaviour - Method - Function
//  Tính lương()    Tính số ngày nghỉ còn lại()     Tính tuổi()     Tính bill()

//>>>>>>>>>CÔNG THỨC LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG OOP

//1. Nhận diện xung quanh bài toán các Object (Đặc điểm và hành vi)

//2. Phân loại, gom nhóm, chia nhóm, đặt tên nhóm theo những Object mà có nhiều điểm tương đồng (CLASSIFY - CHIA NHÓM THÀNH CÁC NHÓM - CLASS)
//Nhóm class Student, Lectured, Dog, Cat,..
//Tạo Class (Đại diện cho 1 đám Object)
// Đặc điểm ID:_______________
//          NAME:_____________
//          YOB:______________
//Class như 1 Template, Form, Biểu mẫu, Blue-Print, Khuôn dùng để đức ra, Clone ra, Copy ra, Nhân bản ra các Object

//3. Mỗi Form, biểu mẫu, khuôn cần được lôi ra, clone, đỗ mực, vật liệu, điền info lên để thành Object, cái hành động này chính là ứng với hàm Constructor
// Ứng với hành động lấy mực điền vào form
// Ta tạo Constructor đổ info vào object

//4. Khi ta điền xong cái form, bài thi trắc nghiệm, cầm lên
// Ta dòm nó, thấy nó, nhìn tấy nó -> GET()  VIEW()  SEE()
// Ta thấy có đáp án ko ổn, ta gôm/tẩy, sửa => SET()   SETTING()  SETTER()

//5. Khi ta tạo xong Account trên mạng xã hội, ta sẽ show profile, show hết Info có thể
// Khi xuất xưởng con điện thoai, để kèm cái hướng dẫn sử dụng, thông tin cấu hình vào cái hộp
// Khoe Info của 1 Object -> SHOWPROFILE()   TOSTRING()

//Vậy lập trình OOP là tạo Class, lập trình thêm template, form, chung chung nhất
//Y chang giải phương trình bậc 2 trên A B C, Sau này đưa Info cụ thể

//Từ Object ra được Class -> Từ Class trở lại Objetc cùng nhóm -> Kỹ thuật quản lý Info qua OOP

//6. CLONE OBJECT Từ Khuôn, New Object, New cái Form, New đúc tượng từ khuôn
//Toán tử New giống Photocopy 1 cái Form, rồi điền Info vào riêng của mình - Object