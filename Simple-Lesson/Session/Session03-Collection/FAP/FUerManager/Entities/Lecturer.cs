using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUerManager.Entities
{
	public class Lecturer
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public int Yob { get; set; }
		public double Salary { get; set; }
		public override string ToString() => $"Id: {Id} | Name: {Name} | Yob: {Yob} | Salary: {Salary}";
		public void ShowProfile() => Console.WriteLine(ToString());
	}
}
