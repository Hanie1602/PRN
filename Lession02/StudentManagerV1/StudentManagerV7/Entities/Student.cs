using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerV7.Entities
{
    internal class Student
    {
        private string _id;     //BACKING FIELD
        private string _name;   //CHỐNG LƯNG, HẬU TRƯỜNG CHO THẰNG
        private int _yob;       //GET SET STYLE MỚI
        private double _gpa;

        public string Id        //được gọi là PROPERTY
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Yob
        {
            get => _yob;
            set => _yob = value; 
        }

        public double Gpa
        {
            get => _gpa;
            set => _gpa = value;
        }

        //Xài GetGpa() thì .Gpa xong - sờ biến thì chính là Get()
        //Xài SetGpa(999) thì .Gpa = 9.99 - = chính là Set()

        //in thử info object, flex object
        public void ShowProfile()
        {
            Console.WriteLine($"Id: {_id} | Name: {_name} | Yob: {Yob} | Gpa: {Gpa}");
            //                                                                _gpa
        } //Xài biến tức là xài Get(), tức là return _

    }
}
