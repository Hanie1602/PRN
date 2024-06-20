using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerV2.Entities
{
    public class Student
    {
        private string _id;
        private string _name;
        private int _yob;
        private double _gpa;

        //Phễu, constructor: đổ data từ ngoài vào trong
        //Ctrl . -> generate constructor & ToString
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

        public void SetYob(int yob) => _yob = yob;
        public void SetGpa(double gpa) => _gpa = gpa;

        public override string? ToString() => $"Id: {_id} | Name: {_name} | Yob: {_yob} | Gpa: {_gpa}";
        
        //public override string? ToString()
        //{
        //    return $"Id: {_id} | Name: {_name} | Yob: {_yob} | Gpa: {_gpa}";
        //}

    }
}
