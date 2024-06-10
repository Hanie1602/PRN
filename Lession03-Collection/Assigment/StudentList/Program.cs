using StudentList.Entities;
using StudentList.Services;

namespace StudentList
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//đi mua cái tủ đựng hồ sơ, 2 cái tủ luôn cho máu
			Cabinet tuSE = new Cabinet();   //Có sẵn ngăn 30 chỗ đựng hồ sơ
											//Đang empty _count = 0;
			Cabinet tuBiz = new Cabinet();

			//Có thêm 30 ngăn khác, empty count = 0. 2 vùng new riêng biệt, 2 tủ riêng biệt
			tuSE.AddAStudent(new Student() { Id = "SE1", Name = "An" });
			tuSE.AddAStudent(new Student() { Id = "SE2", Name = "Bình" });
			tuSE.AddAStudent(new Student() { Id = "SE3", Name = "Cuong" });

			tuBiz.AddAStudent(new Student() { Id = "SS1", Name = "Dung" });

			//In tủ
			tuSE.PrintStudentList();
			tuBiz.PrintStudentList();
            Console.WriteLine("=========================================================");

			//BÀI TẬP VỀ NHÀ
			//VIẾT THÊM BÊN MAIN() CÁI MENU IN RA
			//1. THÊM MỚI: NHẬP BÀN PHÍM, NHỚ CONVERT TỪ CHUỖI SANG SỐ, KIỂU INTEGER.PARSEINT() -> HỎI CHATGPT
			//2. IN
			//3. XÓA SỬA GÌ ĐÓ (KO BẮT BUỘC)

			//VIẾT THÊM TỦ ĐỰNG HỒ SƠ GIẢNG VIÊN: ID, NAME, YOB, SALARY,...

			//HỌC GENERIC <> LIST<STUDENT>
			Cabinet student = new Cabinet();
			CabinetTeacher teacher = new CabinetTeacher();

			while (true)
			{
				Console.WriteLine("\nMenu");
				Console.WriteLine("1. Add a new student");
				Console.WriteLine("2. Add a new teacher");
				Console.WriteLine("3. Print student list");
				Console.WriteLine("4. Print teacher list");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						Console.Write("Enter Student ID: ");
						string studentId = Console.ReadLine();
						Console.Write("Enter Student Name: ");
						string studentName = Console.ReadLine();
						Console.Write("Enter Student Year of Birth: ");
						int studentYob = int.Parse(Console.ReadLine());
						Console.Write("Enter Student GPA: ");
						double studentGpa = double.Parse(Console.ReadLine());

						Student stu = new Student
						{
							Id = studentId,
							Name = studentName,
							Yob = studentYob,
							Gpa = studentGpa
						};

						student.AddAStudent(stu);
						break;

					case "2":
						Console.Write("Enter Teacher ID: ");
						string teacherId = Console.ReadLine();
						Console.Write("Enter Teacher Name: ");
						string teacherName = Console.ReadLine();
						Console.Write("Enter Teacher Year of Birth: ");
						int teacherYob = int.Parse(Console.ReadLine());
						Console.Write("Enter Teacher Salary: ");
						double teacherSalary = double.Parse(Console.ReadLine());

						Teacher t = new Teacher
						{
							Id = teacherId,
							Name = teacherName,
							Yob = teacherYob,
							Salary = teacherSalary
						};

						teacher.AddTeacher(t);
						break;
					case "3":
						student.PrintStudentList();
						break;
					case "4":
						teacher.PrintTeacherList();
						break;
					case "5":
						return;

					default:
						Console.WriteLine("Invalid choice. Please try again.");
						break;
				}
			}
		}
	}
}
