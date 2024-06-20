using FUerManager.Entities;
using FUerManager.Services;

namespace FUerManager
{
	internal class Program
	{
		static void Main(string[] args)
		{
			StudentCabinet tuSEStudent = new StudentCabinet(10);
			tuSEStudent.AddStudent(new Student() { Id = "SE1", Name = "An"});
			tuSEStudent.AddStudent(new Student() { Id = "SE2", Name = "Binh"});

			tuSEStudent.PrintStudentList();

            //Mua cái tủ đựng hồ sơ giảng viên
            Console.WriteLine();
            LecturerCabinet tuSELecturer = new LecturerCabinet(10);
			tuSELecturer.AddLecturer(new Lecturer() { Id = "00012345", Name = "AN", Salary = 20000000 });
			tuSELecturer.AddLecturer(new Lecturer() { Id = "00012346", Name = "AN", Salary = 20_000_000 });
			//_ Dùng để phân cách phần ngàn trong code cho dễ đọc code
			//Java y chang
			//SWP391: Khi in bill, payment, tổng tiền thanh toán phải format phần ngàn -> trừ điểm

			tuSELecturer.PrintLecturerList();
		}
		
	}
}
