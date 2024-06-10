using FUerManager.Entities;
using FUerManagerV2Generic.Services;

namespace FUerManagerV2Generic
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Mua tủ đựng hồ sơ sinh viên

			//Mua thêm 1 cái tủ đựng hồ sơ giảng viên

			//Mua thêm 1 cái tủ quản lý info các bé cưng Pet: Dog, Cat,...

			//Cabinet<Student> tuSEStudent = new (10);
			Cabinet<Student> tuSEStudent = new Cabinet<Student>(10);
			//List<Student> list		 = new ArrayList();

			tuSEStudent.Add(new Student { Id = "SE1", Name = "AN"});
			tuSEStudent.Add(new Student { Id = "SE2", Name = "Binh"});

            Cabinet<Lecturer> tuSELecturer = new Cabinet<Lecturer>(10);

			tuSELecturer.Add(new Lecturer { Id = "00012345", Name = "AN", Salary = 20_000_000});
			tuSELecturer.Add(new Lecturer { Id = "00012346", Name = "AN", Salary = 25_000_000});

			tuSEStudent.PrintAll();
			tuSELecturer.PrintAll();
		}
	}
}
