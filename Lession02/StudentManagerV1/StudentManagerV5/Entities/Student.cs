using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerV5.Entities
{
    internal class Student
    {
        private string _id;
        private string _name;
        private int _yob;
        private double _gpa;

        //ctor tab: sinh ra contructor 1 cách chủ động
        public Student()
        {

        }

        public Student(string id, string name, int yob, double gpa)
        {
            _id = id;
            _name = name;
            _yob = yob;
            _gpa = gpa;
        }

        public Student(string id, string name)
        {
            _id = id;
            _name = name;
        }

        //Contructor còn lại có tham số dùng Ctrl .
        //n cách để đúc 1 object!!!!
        //Hoàn thiện 1 object ta dùng hàm Set().

        public string GetId() => _id;
        public void SetId(string id) => _id = id;
        public string GetName() => _name;
        public void SetName(string name) => _name = name;
        public int GetYob() => _yob;
        public void SetYob(int yob) => _yob = yob;

        public override string ToString() => $"ID: {_id} | Name: {_name} | Yob: {_yob} | Gpa: {_gpa}";

        public void ShowProfile() => Console.WriteLine($"ID: {_id} | Name: {_name} | Yob: {_yob} | Gpa: {_gpa}");
    }
}
