using StudentManagerV4.Entities;

namespace StudentManagerV4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("SE1", "An");
            //Nếu class không có contructor thì C# và Java sẽ tự sinh ra cho mình 1 contructor rỗng, default để giúp ta clone 1 vùng RAM chứa object toàn là Info default. Giống như xin 1 cái form để dành điền sau
            //Nếu đã có 1 constructor có tham số, hoặc nhiều constructor, thì Java và C# ko sinh ra default
            //Lý do: cần contructor để đúc object, mà giờ có rồi thì ko cần sinh ra nữa
            //Nhưng....
            //Em thích làm contructor rỗng 1 cách chủ động
            //EXPLICIT - tường minh, rõ ràng
        }
    }
}
