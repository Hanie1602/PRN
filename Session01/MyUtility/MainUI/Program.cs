using MainUI.Lyrics;

namespace MainUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //new Program().GetAge();
            //PrintLyricOrPoem();
            //GetAge();
            //UseVerbatim();

            LyricsLibrarys.PrintChungTaCuaTuongLai();
        }

        //verbatim string dùng để  làm gì???
        //1 trong những cách dùng là dùng để gán đường dẫn tập tin trong Windows làm cho đường dẫn tự nhiên như lúc xài Windows
        //verbatim còn hay dùng trong chuỗi kết nối cơ sở dữ liệu khi tên server có dấu // \\
        static void UseVerbatim()
        {
            //Cách sử dụng verbatim
            //Dùng trong đường dẫn tên tập tin khi có các kí tự đặc biệt liên quan đến \
            //Đôi khi verbatim còn dùng trong chuỗi URL, connection string - chuỗi kết nối CSDL có thông tin server \ hay /
            //string filePath = "C:\\news:";
            string filePath = @"C:\news:";  //verbatim để dùng chuỗi nguyên bản tự nhiên như nó vẫn là
                                            //\n là \n chứ ko phải xuống hàng
                                            //kết hợp được với interpolation $

            Console.WriteLine(filePath);
            Console.WriteLine(@$"Your path: {filePath} \n\n");
        }

        //OOP: static chơi với static
        static void PrintLyricOrPoem()
        {
            //Console.WriteLine("Từ ấy trong tôi bừng nắng hạ");
            //Console.WriteLine("Mặt trời chân lý chói qua tim");
            //Console.WriteLine("Hồn tôi là một vườn hoa lá");
            //Console.WriteLine("Rất rộn hương và rộn tiếng chim");

            //Ctrl + K + C: comment, Ctrl + K + U: un-comment, mở ghi chú ra của 1 đám lệnh
            //Java: Ctrl /

            //Console.WriteLine("Từ ấy trong tôi bừng nắng hạ\n" +
            //    "Mặt trời chân lý chói qua tim\n" +
            //    "Hồn tôi là một vườn hoa lá\n" +
            //    "Rất rộn hương và rộn tiếng chim");

            Console.WriteLine(@"
Từ ấy trong tôi bừng nắng hạ
Mặt trời chân lý chói qua tim
Hồn tôi là một vườn hoa lá
Rất rộn hương và rộn tiếng chim



Liệu mai sau phai vội mau không bước bên cạnh nhau (bên cạnh nhau)
Thì ta có đau? (Thì ta có đau? Có đau?)
Đôi mi nhòe phai ai sẽ lau?
Ai sẽ đến lau nỗi đau này?
Vô tâm quay lưng ta thờ ơ, lạnh lùng băng giá như vậy sao? (Vậy sao? Vậy sao?)
Vờ không biết nhau (không biết nhau, không biết nhau)
Lặng im băng qua chẳng nói một lời (chẳng nói một lời)
Ooh-whoa-ooh-whoa-oh-oh-oh (yeah, eh)




<html>
    <body>
        <div>
            </div>
    </body>
</html>
");
        } //@ biến chuỗi thành chuỗi nguyên bản - raw string, có gì in nấy
          // phế võ công tất cả các ký tự đặc biệt có trong chuỗi, trở lại thành ký tự bình thường, \n là \n chứ ko phải xuống hàng - Verbatim (Java có luôn)
          // Dùng VERBATIM để làm gì???

        static void GetAge()    //Hàm khai báo theo cú pháp PasCal
        {
            int yob = 2003; //biến khai báo trong hàm theo cú pháp
            //con lạc đà - camel Case Notation, ex: salary, radius, basicSalary
            int age = 2024 - yob;

            Console.WriteLine("Yob: " + yob + " | Age: " + age);   //cw tab giống sout tab
                                                                   //ghép chuỗi style truyền thống - string concatenated dùng dấu +
            Console.WriteLine("Yob: {0} | Age: {1}", yob, age); //place holder - điền vào chỗ trống
            //                      thứ tự biến tính từ 0
            //                      danh sách biến sau dấu phẩy
            //                      %d, yob như bên C
            Console.WriteLine($"Yob: {yob} | Age: {age}");   //Interpolation
            //tự suy luận đâu là biến để điền giá trị của biến vào chuỗi
        }
    }

}
