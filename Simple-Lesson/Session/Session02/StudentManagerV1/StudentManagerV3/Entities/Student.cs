using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerV3.Entities
{
    internal class Student
    {
        private string _id;
        private string _name;
        private int _yob;
        private double _gpa;

        //Nếu 1 cái khuôn ko làm cái phễu, thì ta vẫn đúc được 1 object mang không khí bên trong - mặc nhiên vẫn có được object ko khí
        //Mặc nhiên có sẵn gọi là Default
        //Đối với Java, C#. Nếu bạn ko làm contrructor/phễu để đúc object, thì Java, C# cung cấp sẵn cho bạn 1 phễu trống không, ko nhận đầu vào, cũng chẳng có xử lý gán đồ ra vô, cái contructor default
        //Dạng public Student() {}
        //Bạn dùng nó để new như bình thường, sẽ tạo ra 1 vủng nre chứa toàn info defaut, nhưng vẫn là object
        //Nó y chang ngoài đồi, bạn mua 1 căn nhà thô, bạn photo 1 tò giấy/form điền -- new rồi
        //Từ từ điền vào sau, từ từ trang trí deco sau
        //Bản chất vẫn là có nhà, có giấy, có form, có object

        public override string ToString() => $"{_id} | {_name} | {_yob} | {_gpa}";
    }
}
