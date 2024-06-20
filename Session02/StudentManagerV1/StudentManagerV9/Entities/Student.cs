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
        //RUNTIME tự sinh ra giúp ta _id, _name, _yob, _gpa
        //Lúc chạy App
        //Giúp dân Dev viết code tiện hơn, tránh những code nhàm chán

        //Lỡ quên cú pháp, gõ prop tab
        //public int MyProperty { get; set; }
        //Bên Java ko có trò này, muốn làm trò này phải cài thêm Dependency bên ngoài, thư viên ngoài - thư viện LOMBOK.
    }
}


//CHỐT HẠ: Các thiết kế 1 class lưu trữ info các object
//Cách 1: Khai báo các Backing Fied như bên Java (_)
//        Sau đó làm các hàm Get() Set() như Java
//
//Cách 2: Khai báo các _BACKING FIELD như bên Java (_)
//        Sau đó làm hàm Get() Set() theo style viet1 gộp
//        Và xử lý trên _BACKING FIELD, dùng thêm => nếu cần
//        public string Name { get => _name; set => _name = value}
//        * QUÊN CÚ PHÉP, THÌ GÕ propfull tab
//        * CÁCH NÀY ĐƯỢC GỌI LÀ FULL PROPERTY (Hàm + _backing field)
//
//Cách 3: Khai báo hàm Get Set() Style ngắn gọn, ko thèm xài _BACKING FIELD luôn, RUNTIME tự chế ra BACKING FIELD
//      public string Name {get; set;}

//      * Quên cú pháp, thì gõ prop tab tab
//      * Cách này được họi là Auto-Implementer property
//        (runtime tự sinh ra _backing gield cho ta)
//
//Cách 4: Khai báo _backing field như bình thường (như Java)
//        Chủ động viết riêng các hàm Get() Set() truyền thống
//        Hoặc ko có hàm Get() Set() nhưng có các hàm  khác
//        xử lý _backing field