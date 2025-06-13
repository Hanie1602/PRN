using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ~ package bên Java là 1 thư mục trên HDD/SDD dùng để lưu trữ các class/source code!!
//Nếu thư mục cha có thư mụ con, có thư mục cháu thì chạm đến class thư mục cháu sẽ là:
//  Cha.Con.Cháu. cái class mình muốn dùng
//y chang bên Java
//Muốn xài class thì phải chỉ ra đường đi
//Bên java đường đi sẽ là
//import java.until.Scanner;

//C#:
//using Cha.Con.Cháu;
//Mục đích của việc tạo ra namespace/package: hộp chứa class để giúp phân loại, quản lý source code, quản lý các class theo các mục địch khác nhau: nhóm class Controller, nhóm class DAO, nhóm class DTO...
//Nhờ chia class vào trong các thư mục cho nên 2 thư mục khá nhau có quyền chứa 2 class trùng tên
//Nhà Mình . thằng Tèo
//Nhà hàng xóm . thằng Tèo
//Giải quyết vấn đề đụng độ tên gọi; clash of naming!!!
namespace MainUI.Lyrics
{
    internal class LyricsLibrarys
    {
        public static void PrintChungTaCuaTuongLai()
        {
            Console.WriteLine(@"
Yah, yah
Tương lai ngày mai ai nào hay (whoa)
Yêu thương rồi buông đôi bàn tay (whoa)
Mong manh đường duyên như vận may
Chia ly, hợp tan nhanh còn hơn mây trời bay (yah)
Quên nhau, vờ như chưa từng quen (sao quên?)
Quên luôn mặt, quên luôn cả tên (sao quên?)
Quên đi, làm sao mà đòi quên?
Khi câu thề xưa vẫn vẹn nguyên nên đừng cố quên (ah)
Vấn vương cũng chẳng sao mà (whoa), nhớ nhung cũng chẳng sao mà (whoa)
Đớn đau cũng chẳng sao mà (whoa)
Dù có đắng cay ta cũng chẳng sao đâu
Chân thành khi còn bên nhau và trân trọng hơn mỗi phút giây (hơn mỗi phút giây)
Thành thật bên nhau mỗi phút giây (yeah, yeah)
Rồi niềm đau có chóng quên? (Hah-ah-ooh-ah)
Hay càng quên càng nhớ thêm, vấn vương vết thương lòng xót xa? (Whoa-oh-oh-oh-oh-oh-oh)
Đừng như con nít (con nít), từng mặn nồng say đắm say (oh-oh-ah)
Cớ sao khi chia tay (chia tay), ta xa lạ đến kì lạ? (Ta xa lạ đến kì lạ, hah)

");
        }
    }
}
