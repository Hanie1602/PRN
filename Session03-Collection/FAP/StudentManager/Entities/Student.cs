using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace StudentManager.Entities
{
	public class Student
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public int Yob { get; set; }
		public double Gpa { get; set; }

		//Làm biếng, làm contructor, thì xài contructor default + object initializer để fill info

		public override string ToString() => $"{Id} | {Name} | {Yob} | {Gpa}";
		
		public void ShowProfile() => Console.WriteLine(ToString());
	}
}
