using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ArrayStudent.Entities
{
	internal class Student
	{
		public string Id { get; set; }	//AUTO-IMPLEMENTED PROPERTY
		public string Name { get; set; }
		public int Yob { get; set; }
		public double Gpa { get; set; }
		public override string? ToString() => $"{Id} | {Name} | {Yob} | {Gpa}";
		public void ShowProfile() => Console.WriteLine($"{Id} | {Name} | {Yob} | {Gpa}");
	}
}

//tự viết code: id, name, yob, gpa, tostring() showprofile()