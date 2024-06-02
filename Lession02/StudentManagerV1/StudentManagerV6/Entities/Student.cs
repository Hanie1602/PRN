using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerV6.Entities
{
    internal class Student
    {
        private string _id;
        private string _name;
        private int _yob;
        private double _gpa;

        //Các cặp Get() Set()
        public string GetId()
        {
            return _id;
        }
        public void SetId(string id)
        {
            _id = id;
        }

        public string Name      //PROPERTY; LAI GIỮA HÀM GET() SET()
                                //VÀ BIẾN THÔNG THƯỜNG string Name
        {
            get { return _name; }
            set { _name = value; }
        }  //Style này: lợi dụng rằng khai báo 1 biến chính là đã khai báo luôn 2 thứ get value của biến, set value của biến

        public int GetYob() => _yob;
        public void SetYob(int yob) => _yob = yob;
    }
}

//Ctrk K D: format lại code cho đẹp trai