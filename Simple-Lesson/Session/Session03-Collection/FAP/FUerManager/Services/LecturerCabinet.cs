using FUerManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUerManager.Services
{
	public class LecturerCabinet
	{
		private Lecturer[] _arr;
		private int _count = 0;

		public LecturerCabinet(int size) => _arr = new Lecturer[size];

		public void AddLecturer(Lecturer x) => _arr[_count++] = x;

		public void PrintLecturerList()
		{
            Console.WriteLine($"There is/are {_count} lecturer(s) in the cabinet");
			for(int i = 0; i < _count; i++)
				_arr[i].ShowProfile();
        }
	}
}
