using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerV9.Entities
{
    internal class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Yob { get; set; }
        public double Gpa { get; set; }
        //RUNTIME tự sinh ra giúp a _id, _name, _yob, _gpa
        //Lúc chạy App
        //Giúp dân Dev viết code tiện hơn, tránh những code nhàm chán

        //Lỡ quên cú pháp, gõ prop tab
        //public int MyProperty { get; set; }
        //Bên Java ko có trò này, muốn làm trò này phải cài thêm Dependency bên ngoài, thư viên ngoài - thư viện LOMBOK.
    }
}
