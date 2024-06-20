using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerV1.Entities
{
    internal class Student
    {
        //Đặc tính của 1 object, đặc điểm của 1 object thì đc gọi là
        //Field, attribute, "biến"
        //Hành động của 1 object, chính là hàm (hàm là xử lý, hành động)
        //Còn gọi là method
        //Hàm/method + "biến" field gọi chung là MEMBER, Thành viên, Thành phần của 1 object
        private string _id;     //_________________
        private string _name;   //_________________
        private int _yob;       //_________________
        private double _gpa;    //_________________

        public Student (string id, string name, int yob, double gpa)
        {
            _id = id;
            _name = name;
            _yob = yob;
            _gpa = gpa;
        }

        //BỘ HÀM CHỈNH SỬA INFO CỦA 1 OBJECT, SET, SETTER
        //Chỉnh sửa Info nghĩa là pahi3 đưa info mới vào !!! Đè vào info cũ, giống như ta mua  cái điện thoai, ta upload hình bạn trai/gái đề hình nền mặc định của cái điện thoại, ngoài ---> Đổ vào trong
        public void SetGpa(double gpa) => _gpa = gpa;

        public void SetYob(int yob) => _yob = yob;  //EXPRESSION BODY, rút gọn tên hàm khi chỉ có 1 lệnh



        public void ShowProfile()
        {
            Console.WriteLine("Here is my profile");
            Console.WriteLine("ID: " + _id);
            Console.WriteLine("Name: {0}", _name);
            Console.WriteLine($"Yob: {_yob}");
            Console.WriteLine($@"Gpa: {_gpa}");
        }

        //@Override
        public override string ToString()
        {
            return $"ID: {_id} | Name: {_name} | Yob: {_yob} | Gpa: {_gpa}";
        }
    }
}

//Object - Đối tượng: là 1 thứ quanh ta, dùng nhiều lời để mô tả về nó: cây bút trên tay có giá tiền, hãng sản xuất, màu sắc,....
//Đối tượng được mô tả qua đặc điểm, và hành vi - hành động
//bé cưng nhà mình có: tên, năm sinh, đã chích vacxin, hành động: dụi má vào tay, cào ghế nệm,...
//Các đối tượng đều được cho 1 cái tên  gọi - Danh từ riêng
//Cái bút của tôi, bé cưng nhà bạn, tui, bạn, ku Tèo, ku Tí, sếp, thằng kia, ChiPu,...
//Danh từ riêng: tên gọi cho 1 đối tượng cụ thể nào đó

//Các đối tượng quanh ta, được chia thành các nhóm dựa theo đặc điểm chung, điểm tương đồng, ta gom các đối tượng thành 1 nhóm, đặt cho chúng 1 cái tên - Class xuất hiện
//Class là tên gọi chung, danh từ chung cho 1 nhóm đối tượng tương đồng
//Class Student đại diện cho 1 nhóm bạn An, Bình, Cường, Dũng
//Class như khuôn dùng để đúc ra các đối tượng
//Student có An, Bình, Cường, Dũng, em, Giang, Hương, Khánh, Minh,...
//Các object này đều chia sẽ đặc tính: id, name, yob, gpa,...

//Từ đối tượng --> Tìm ra class nhóm đối tượng
//Từ CLASS -> CLONE ra object mới
//Giúp ta quản lí mọi object, mọi info quanh ta