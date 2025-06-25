using FUerManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUerManager.Services
{

	//void F(int size) {....}
	//		int là data type, kiểu dữ liệu, loại dữ liệu, hình dáng của thông tin: int: 1 con số nguyên (the whole number - nguyên con không lẻ miếng nào)
	//Hàm F cần 1 con số nguyên nào đó
	//void F (int size)
	//				size: là data, dữ liệu cụ thể nào đó, 1 con số nào đó bất kì, miễn là nguyên
	//void F (int size)
	//		int : cố định, hàm chơi số nguyên
	//		size: thay đổi, value, con số nguyên cụ thể
	//TRUYỀN THỐNG: Hàm nhận vào tham số, nghĩa là data type cố định, value của data type thì thay đổi
	//TRUYỀN THỐNG: TRUYỀN THAM SỐ CHÍNH LÀ TRUYỀN 1 "VALUE"
	//												  THAM TRỊ, THAM CHIẾU.

	//HIỆN ĐẠI: Data type được quyền thay đổi, giống như tham số của hàm
	//Hàm bây giờ chấp nhận đầu vào/tham số đầu vào có 2 sự thay đổi
	//		VOID F(???? BIẾN)
	//			   ???? có thể là bất kì 1 data type nào đó: Student, Lecturer, Tiger...
	//Sau khi xác định được data type, ta mới xác định tiếp giá trị của biến thuộc data type đó.

	//Void F(Student biến)
	//Void F(Lecturer biến)
	//Kỹ thuật truyền vào 1 data type, data type được truyền vào 1 hàm, class (Để xác định class sẽ làm việc với data type nào)
	//Data type là tham số luôn ==> kỹ thuật này được gọi là Generic
	//Cái kí tự <Data type muốn truyền vào class, hàm> khiến cho hàm và class có thể chơi được với nhiều loại data type!!!!!

	//Generic repository & Unit of work
	//Patterns: => 1khuôn mẫu, cách thức thiết kế về code/class

	public class StudentCabinet
	{
		//private Student[] _arr = new Student[30];			//Hard-code
		private Student[] _arr;
		private int _count = 0;		//Chưa có biến nào trong mảng được gắn value. Sau này for thì chỉ for đến _count tránh Null Reference Exception

		//Đóng tủ mà có kích thước theo yêu cầu
		public StudentCabinet(int size)
		{
			_arr = new Student[size];	//Mảng có kích thước tùy chỉnh
		}

		//CRUD Method
		public void AddStudent(Student s) => _arr[_count++] = s;

		public void PrintStudentList()
		{
            Console.WriteLine($"There is/are {_count} student(s) in the cacbinet");

			//Không được for hết mảng, kẻo null exception - học rồi
			for(int i = 0; i < _count;  i++)
				_arr[i].ShowProfile();
        }
	}
}
