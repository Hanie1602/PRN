namespace NullValue
{
    internal class Student
    {
        //C# gợi ý cách viết coded phần cơ bản của 1 class cực nhanh gọn, học sau!!!!
        //Quay lại truyền thống:
        //class gồm: field + hàm/method => members thành viên  của 1 class
        //ENCAPSULATION: 
        private string _id;  //con lạc đà và gạch chân từ đầu tiên
        public string _name;
        private int _yob;
        private double _gpa;

        public Student(string id, string name, int yob, double gpa)
        {
            _id = id;
            _name = name;
            _yob = yob;
            _gpa = gpa;
        }

        public void ShowProfile()
        {
            Console.WriteLine($"ID: {_id} | Name: {_name} | Yob: {_yob} | GPA: {_gpa}");
        }
    }

    internal class StudentNull
    {
        //C# gợi ý cách viết coded phần cơ bản của 1 class cực nhanh gọn, học sau!!!!
        //Quay lại truyền thống:
        //class gồm: field + hàm/method => members thành viên  của 1 class
        //ENCAPSULATION: 
        private string _id;  //con lạc đà và gạch chân từ đầu tiên
        public string _name;
        private int _yob;
        private double? _gpa;

        public StudentNull(string id, string name, int yob, double? gpa)
        {
            _id = id;
            _name = name;
            _yob = yob;
            _gpa = gpa;
        }

        public void ShowProfile()
        {
            Console.WriteLine($"ID: {_id} | Name: {_name} | Yob: {_yob} | GPA: {_gpa}");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //CreateStudentObject();
            //PlayWithNullable();
            //PlayWithNullV1();
            //PlayWithNullV2();
            //PlayWithNullV3();
            //PlayWithNullV4();
            PlayWithNullableV2();
        }

        static void PlayWithNullableV2() 
        {
            int a = 0;
            //int b = null;   //Bị chửi ngay lúc gõ code vì lý do. Đây là biến PRIMITVE (JAVA) C# value type
                            //Là biến, là vùng RAM lưu 1 giá trị đơn lẽ nào đó
                            //Số, ký tự: int, long, float, double
                            //Biến style đơn giản này phải gán 1 giá trị hợp lệ, ko cho null

            int? c = 0;     //Vẫn in bình thường nhưng
                            //Nhưng có thể mang têm giá trị null
                            //Để match với 1 cột null trong DB

            //? ?? y chang như đã học
            Student s1 = null;
            Student? s2 = null;

            //Với kiểu dữ liệu class/object
            //Mặc nhiên là được dùng null để mô tả trạng thái tui chưa trỏ ai
            //Tui chưa xác định - dùng kết quả trả về của search

            //Dùng thêm ? cũng chẳng ảnh hưởng
            //? Đi kèm Data Type được gọi là: NULLABLE
            //Em có khả năng chứa giá trị null và áp dụng chung cho
            //Cả 2 kiểu PRIMITIVE và OBJECT

        }

        //static void PlayWithNullV4()
        //{
        //    Student s1 = null;
        //    Student s2 ?= s1;
        //}

        static void PlayWithNullV3()
        {
            int yob = 2004;
            string msg;
            //Nếu năm sinh > 2000 thì in ra GenZ
            //Ngược lại in ra: Outdate
            //if (yob > 2000)
            //    msg = "GenZ";
            //else
            //    msg = "Outdate";
            //Console.WriteLine(msg);

            msg = yob > 2000 ? "GenZ" : "Outdate";
            Console.WriteLine(msg);
            //Toán tử tình tay ba - CONITIONAL TERNARY OPERATIOR
            //Toán tử 3 ngôi!!!!
            //Mệnh đề đúng sai trong phép toán này ko hẳn là check null, mà là bất kì mệnh đề so sánh nào
            //Chỉ cần đúng sai, ko cần có đúng null ko, có đúng null ko
            //Mình dùng ? này cũng Okie, hoặc dùng ??

            Student s1 = null;
            //Student s2 = s1 == null ? new Student ("SE2", "HAI", 2002, 2.2) : s1;
            Student s2 = s1 != null ? s1 : new Student("SE2", "HAI", 2002, 2.2);
            s2.ShowProfile();
        }

        static void PlayWithNullV2()
        {
            Student s1 = null;
            Student s2 = s1;        //s2 cũng bằng null luôn

            Student s3 = null;
            Student s4 = s3 ?? new Student("SE4", "BON", 2004, 4.4);
            s4.ShowProfile();

            //VIẾT LẠI THÌ NÓ LÀ:
            if (s3 == null)
                s4 = new Student("SE4", "BON", 2004, 4.4);
            else
                s4 = s3;
            //Kỹ thuật này đảm bảo rằng biến sẽ có giá trị nào đó, được gán giá trị nào đó | Đừng nhầm với biến?Gọi hàm() - NULL CONDITION
            //Kỹ thuật này dùng để gán giá trị DEFAULT cho 1 biến, khi ngộ nhỡ vế been6 phải có thành phần là null. Thì mình có giá trị dự phòng
            //Kỹ thuật này gọi là: COALESING -  Toán tử kết nối, kết hợp

            Student s5 = new Student("SE5", "NAM", 2005, 5.5); ;

            Student s6 = s5 ?? new Student("SE6", "SAU", 2006, 6.6);
            s6.ShowProfile();

            //2 chàng trỏ 1 nàng
        }

        static void PlayWithNullV1()
        {
            Student s1;
            //s1.ShowProfile();   //bị chửi, vì biến lưu rác, ko chấm gọi hàm được, rác thì ko có hàm để chạy
                                  //Java và C#: khai báo biến mà ko gán giá trị, cấm ko được dùng ở lệnh dưới đó
                                  //Tệ nhất phải gán null - Trỏ vào đáy RAM, BYTE 0; - Giống như kim đồng hồ xe máy, số tốc độ
                                  //Nếu xe ko chạy kim, số nhảy về 0
            Student s2 = null;
            //s2.ShowProfile();           //RUNTIME ERROR!!!!
            //Để tránh Runtime, ta dùng if, hoặc gán tử tế biến object rồi mới chấm hàm để dùng!!!
            //Tại sao có NULL để phải check: dính đến kết quả search có thể thấy và ko thấy object! Ko thấy thì trả về null
            if (s2 is null)     //if (s2 == null)       if (s2 is not null)
                Console.WriteLine("Please assigning or create an object first before printing it");
            else
                s2.ShowProfile();
            //Cách viết trên hơi dài 1 tí, nhưng ổn

            Student s3 = null;
            Console.WriteLine("s3 checking....");
            s3?.ShowProfile();
            //NULL CONDITION OPERATR
            //Là ký hiệu, phép toán, phép so sánh, kiểm tra 1 object có null hay ko trước khi gọi hàm của nó
            //Viết gộp c ủa if và else
            //Tránh bị RUNTIME ERROR

            Console.WriteLine("");
            Student s4 = new Student("SE4", "BON", 2004, 4.4);
            Console.WriteLine("s4 checking....");
            s4?.ShowProfile();
        }

        static void PlayWithNullable()
        {
            Student s3 = new Student("SE1", "An", 2004, 7.9);
            StudentNull s4 = new StudentNull("SE2", "An", 2004, null);

            //Kiểm tra ku s4
            s3.ShowProfile();
            s4.ShowProfile();

            //Null tại thời điểm này chỉ áp dụng cho biến object để trỏ vào vùng an toàn byte thứ 0
            //Mang ý nghĩa chưa có sv mà đó cần quan tâm, tìm thấy khi search!!!
            //Không áp dụng cho biến primitive (Java)
            //C# offer 1 cơ chế: biến primitive null luôn để tương thích null trong database, cột điểm gpa trong db là null
            //Trong code double gpa = null???

            double? gpa = 9.0;
            gpa = null;
            //Ta có int? long? double? float? char? bool?
            //Vẫn mang giá trị như xưa nay, và còn đc gán thêm null
            //Style này gọi là nullable 
        }

        static void CreateStudentObject()
        {
            //Tạo mới hồ sơ sinh viên - tạo mới object từ template/class Student
            //Có khuôn - Class ta clone clone
            Student s3 = new Student("SE1", "An", 2004, 7.9);   //79 thần tài lớn
            s3.ShowProfile();

            Student s1;                 //Xin RAM mà thôi
            //s1.ShowProfile();           //Vùng RAM chứa Rác - GARBAGE VALUE
                                        //Rác on off của APP trước để lại
            //Trong Java và C# nếu khai báo biến mà ko gán Value thì:
            //Cấm ko dc xài biến ở các câu lệnh phía dưới
            //Dù biến là int, long, float, double, char hay Student, lecturer, pet, dog......
            int currentYear;
            //Console.WriteLine(currentYear);     //bị chửi vì biến trong RAM đang chứa rác - in rác thì có ý nghĩa gì??? Nhưng C in rác luôn
            currentYear = 2024;
            Console.WriteLine("Current Year: " + currentYear);
            //Khai báo biến xong phải gán value cho biến (chấp loại biến nào, primitive với object)

            Student s2 = null;  //xin RAM, dọn dẹp RAM sạch sẽ, trỏ vào vùng NULL - Byte đầu tiên của RAM, đáy của RAM, tầng trệt của căn hộ
                                //2.ShowProfile();   //Bị chửi lúc Run APP - RUNTIME
                                //Vì trỏ vào vùng new student có data đẻ show()

            //s2 = new Student(......);   //Ổn nhen, vì giống S3
            s2 = s3;                //2 chàng trỏ 1 nàng

            s3._name = "Ngoc Trinh em ơi";
            s2.ShowProfile();

            Student s4 = s2;
            //s4.ShowProfile();   //Toang lúc RUNTIME
            if (s4 != null)         //!= == null để check 1 bie1en6 đang trỏ null hay ko
                s4.ShowProfile();
            else
                Console.WriteLine("Please creatung a student object before printing the profile");

            Console.WriteLine("Ngoc Trinh cuoi gio.....");

            if (s4 is not null)     //và is null - viết giống SQL
                s4.ShowProfile();
            else
                Console.WriteLine("Please creatung a student object before printing the profile");
        }
    }
}

//biến object khi khai báo Student s; thì có quyền gán bằng những giá trị sau
// = New 1 vùng object (Gọi constructor)
// = 1 biến Object khác đã new trước đó s2 = s3
// = null trỏ đáy RAM
//Dùng: Search 1 object và ko tìm thấy thì trả về null
//Tìm thấy trỏ vào vùng new student() nào đó


//Một namespace chứa nhiều class
//các class này có thể nằm riêng trên mỗi tập tin hoặc nói cách khá, mỗi tập tin úng với 1 class code
//Nhưng trong 1 tập tin c ẩn có thể có nhiều class, nhưng xài chung 1 tập tin, và 1 tên gì đó .cs
//Làm lẻ: mỗi tập tin 1 class => Thư namespace hoành tráng, nhưng class nào ra class đấy, vì chúng có tên riêng
//Làm rộp: 1 tập tin vật lí có thể gồm nhiều code class bên trong -> thư mục namespace gọn gàng, nhưng ko biết chính xác có bao nhiêu class!!!! Vì các class xài chung 1 tập tin

//thường ko có gì đặt biệt, thì mỗi class 1 tập tin vả share chung thư mực chứa code - share chung namespace
