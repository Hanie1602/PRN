using StudentManagerV3.Entities;

namespace StudentManagerV3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student(); //xài empty, default constructor - đúng cho java luôn
            Console.WriteLine("s1 details by using defult cst: " + s1);     //Gọi thầm tên em

            //Muốn sửa info thì chắc chắn phải là đem nguyên vật liệu về đổ vào - setter, hàm Set()
            //Điều gì xảy ra nếu
            //Class của bạn thiết kế sẵn 1 hay 1 vài contructor có tham số???

        }
    }
}
