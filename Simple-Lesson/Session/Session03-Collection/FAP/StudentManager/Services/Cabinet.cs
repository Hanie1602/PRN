using StudentManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Services
{
	//Cái tủ là 1 thứ (giống cái Form, Template, Khuôn) dùng để lưu trữ nhiều món đồ, nhiều info, info này chính là các Object
	//Ta tạo class Tủ để tương lai ta new từng cái tủ
	//Đi mua cái tủ đi, - new Tủ() - new Cabinet()
	//Mua tủ thì có được ko gian lưu trữ, cất trữ món đồ, nhiều món đồ
	//Để cất trữ nhiều món đồ, ta cần Mảng
	//Đặc tính của cái tủ là cái mảng - ko gian chứa đồ
	//Hành động của tủ: CRUD món đồ
	//CREATE | RETRIEVE/READ | UPDATE | DELETE

	public class Cabinet
	{
		//private Student[] _arr;		//Có new ngay hay ko, new Student[30]
		//Tùy bạn
		private Student[] _arr = new Student[30];
		private int _count = 0;     //Tủ mới mua về , thì chưa có món đồ nào
									//Nhưng nếu có thì tối đa 30 hoặc size!!!

		//Get() Set()
		//Ko có set cho biến _count, vì ảnh hưởng đến đếm số object, hồ sơ sinh viên trong mảng!!! - Biến nội bộ ko có nhu cầu Get() Set() ra ngoài
		//Cùng lắm có thêm hàm Get_count() để biết tủ đang có bao nhiêu đồ
		public int Count => _count;		//Hàm Get() đó nhen, ko phải biến int Count!!!

		public int GetCount()
		{
			return _count;
		}

		//Ta ko làm Get() Set() cho _arr: tại sao???
		//Get() trả về mảng thô, có sao trả về vậy, ko ổn về mặt quản lý data
		//Lẽ ra phải trả mảng đã sắp xếp theo...
		//Vậy trả về mảng phải qua xử lý tính toán rõ ràng -> Vậy phải là 1 hàm có tính toán, chứ ko phải get() thuần
		//Ko làm hàm Get() là hợp lý

		//Hàm Set() Mảng nghĩa là phải chuẩn bị 1 mảng có 1 số lượng sinh viên
		//Rồi Move nhanh 1 nhát vào mảng
		//arr = mảng đã đủ, nhiều Student()
		//Ko thực tế: tủ hồ sơ sẽ được add từ từ!!!
		//SWP: Thêm mới 1 sản phẩm hay nhiều sp cùng lúc!!!!
		//		đơn hàng đến từ từ, giỏ hàng cũng từ từ mới đầy

		//Tạo mới nhiều sản phẩm 1 lúc: chuẩn bị 1 danh sách Excel -> Import
		public Cabinet(int size)
		{
			_arr = new Student[size];       //Tủ đặt hàng ko gian lưu trữ theo yêu cầu
		}

		public Cabinet()
		{

		}

		//BỘ HÀM CRUD!!!!
		public void PrintStudentList()
		{
            Console.WriteLine($"The is/are {_count} student(s) in the list");
			for (int i = 0; i < _count; i++)
				_arr[i].ShowProfile();
        }

		public void AddAStudent()
		{
			//Ta phải có code để nhập info sinh viên ở đây!!!  thì mới new được
			//Nhập này: Console.ReadLine() => Trả về chuỗi => cần số thì convert từ chuỗi về số
			//HÀM NÀY CHỈ CHƠI VỚI CONSOLE -> Kém linh hoạt!!!
			//Vì việc nhập info có thể đến từ Web, WIN FORMS (UI DESKTOP), MOBILE
			//Để đảm bảo thỏa việc nhập, linh hoạt việc nhập, đừng gắn việc Input vào class này, class này lo xử lý info, nhập để nơi khác truyền vào.

		}

		//Gson, Jackson
		public void AddAStudent(string id, string name, int yob, double gpa)
		{
			//Có info ở ngoài truyền vào, new Student() hoy và add vào vị trí thứ [i count] của mảng
		}

		public void AddAStudent(Student s)	//Tốt nhất!!!
		{
			//Có info ở ngoài truyền vào, new Student() hoy và add vào vị trí thứ [i count] của mảng
			if (_count == 30)
			{
                Console.WriteLine("The list is full. No more student profile added!!!");
				return;
            }
			//Đã có return trong if thì ko cần else nữa
			_arr[_count] = s;	//new Student() { };
			_count++;
		}
	}
}

//Nhiều hàm trùng tên nhau, nhưng khác phần tham số - khác trên data type
//Được gọi là overload, overloading
//overload là 1 dạng thể hiện của nguyên lý đa hình POLYMORPHISM