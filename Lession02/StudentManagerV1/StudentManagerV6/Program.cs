namespace StudentManagerV6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static void PlayWithGetSet()
        {
            //Biến là 1 vùng RAM được đặt tên, chứa giá trị nào đó
            //Khi chơi với biến là ta  chơi với vùng RAM, chơi với giá trị, chơi thông qua tên biến
            //Chơi với vùng RAM/với biến ta làm được 2 việc sau:
            //READ VÙNG RAM, Read biến coi nó có value gì???
            //WRITE VÙNG RAM, thay đổi calue của vùng RAM, của biến

            int x = 10;          //Vùng RAM, xx mang giá trị 10 khởi đầu

            //Hãy in ra giá tr5i của biến, của vùng RAM, READ(), GET()
            //Sờ chạm tên biến, là sờ chạm value
            Console.WriteLine("x: " + x);   //GetX() được x

            //Sửa, đổi value, SET() SETTING()
            //Tên biến   dấu bằng chính là sửa SET() Value
            x = 305;    //cuối tháng cuối tuần          //SET() thay đổi
            Console.WriteLine("x again: " + x);     //GetX() đc x


        }
    }
}
