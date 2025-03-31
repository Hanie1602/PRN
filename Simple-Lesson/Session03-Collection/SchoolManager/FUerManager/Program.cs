using FUerManager.Services;
using ListBasic.Entities;

namespace FUerManager
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//PlayWithIntegerCabinet();
			PlayWithStudentCabinet();
		}

		static void PlayWithStudentCabinet()
		{
			Cabinet<Student> tuSE = new();
			tuSE.AddAnItem(new Student() { Id = "SE1" });
			tuSE.AddAnItem(new Student() { Id = "SE2", Name = "Binh" });

			tuSE.PrintItems();
		}


			//			Nguyên tắc thiết kế nâng cao của OOP
			//DESIGN PATTERNS GoF 23 PATTERNS
			//SOLID (DEPENDENCY INJECTION - DI) - Tôi đi code dạo Yotube
			static void PlayWithIntegerCabinet()
		{
			Cabinet<int> loto = new();
			loto.AddAnItem(5);
			loto.AddAnItem(10);
			loto.AddAnItem(15);
			loto.AddAnItem(20);		//type-safe, ko add lộn xộn

			loto.PrintItems();		//DELEGATE
		}

	}
}
