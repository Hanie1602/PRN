using StudentManagerV7.Entities;

namespace StudentManagerV7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tạo mới Student Object và dùng Get Set như bình thường
            Student s1 = new Student();
            //Default cả đám
            Console.WriteLine("s1 (Default)");
            s1.ShowProfile();

            s1.Id = "SE1";       //Tên biến = chính là Set(SE1)
            s1.Name = "An";
            s1.Yob = 2004;
            s1.Gpa = 8.6;
            Console.WriteLine("");
            Console.WriteLine("s1 After Setting");
            s1.ShowProfile();
            Console.WriteLine("");

            //Viết tự nhiên hơn so voi 17 s1.SetName("An");
            //Id, Name, yob, Gpa: được gọi là Property của 1 Object
            //Còn _id, _name, _yob, _gpa nay gọi là Backing Field
            //Đứa đứng sau, chống lưng cho Property, cho hàm GET SET

            //Cách new vi diệu bắt đầu
            //Phối hợp vừa new vừa Set() luôn

            Student s2 = new Student()
            {
                Id = "SE2",
                Name = "Binh",
                Yob = 2004,
                Gpa = 8.7
            };  //Kỹ thuật new kiểu này, new xong, rồi gán luôn SET()
            //Trên cùng 1 câu lệnh (đừng nhầm với NAMED-ARG New trong Constructor - Tham số Contructor)
            //Gọi hàm SET() lúc new
            //Gọi là: Object Initializer

            Console.WriteLine("s2 full");
            s2.ShowProfile();
        }
    }
}
