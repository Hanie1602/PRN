using StudentList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList.Services
{
	public class CabinetTeacher
	{
		private Teacher[] _arr = new Teacher[30];
		private int _count = 0;

		public int Count => _count;     //Hàm Get();

		public int GetCount()
		{
			return _count;
		}

		public CabinetTeacher(int size)
		{
			_arr = new Teacher[size];
		}

		public CabinetTeacher()
		{

		}

		public void PrintTeacherList()
		{
            Console.WriteLine($"The is/are {_count} teacher in the list");
			for(int i = 0; i < _count; i++)
				_arr[i].ShowProfile();
        }

		public void AddTeacher(Teacher t)
		{
			if (_count == 30)
			{
                Console.WriteLine("The list is full");
				return;
            }

			_arr[_count] = t;		//new Teacher() {}
			_count++;
		}
	}
}
