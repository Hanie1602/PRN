using ArrayStudent.Entities;

namespace ArrayStudent
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//CreateStudent();
			PlayWithStudentListV2();
		}

		//CHALLENGE #2: HÃY LƯU THÔNG TIN, HỒ SƠ CỦA 330 BẠN SINH VIÊN TRONG PHÒNG NÀY
		//Giải pháp 1
		//Chơi Ngoo: khai báo 30 biến student
		//chơi hiện đại: khai báo mảng

		static void PlayWithStudentListV2()
		{
			Student[] arr = new Student[30];
			//		má mì có nhiều biến Student, biến hoy nha
			//				s1, s2, s3, s4, s5. Chưa có hồ sơ sinh viên thực sự!!!
			//Mảng primitive: arr[0] = 5; !!!!
			//Mảng object:    arr[0] là 1 sinh viên, trỏ vùng new Student()
			//				  arr[0] = new Student(....){....};

			arr[0] = new Student() { Id = "SE1", Name = "An" };     //Object Initializer
			arr[1] = new Student() { Id = "SE2", Name = "Binh", Yob = 2004 };
			arr[2] = new Student() { Id = "SE3", Name = "Cuong" };
			arr[3] = new Student() { Id = "SE4", Name = "Dung", Yob = 2004, Gpa = 8.6 };

			//IN CHO TUI MẢNG SV THEO 2 CÁCH FOR 1 FOR EACH
			Console.WriteLine("The list of student printed by using for i");
			for (int i = 0; i < arr.Length; i++)
				if (arr[i] != null)
					arr[i].ShowProfile();

			Console.WriteLine("The list of students (for each)");
			foreach (Student x in arr)
				//Console.WriteLine(x);		//Gọi thầm tên em ToString()
				if (x is not null)      //!= null
					x.ShowProfile();
			//ko hay vì phải for đến cuối cho phần null
			//phí CPU khi chạy 6 cuối mà ko i n được

		}

		static void PlayWithStudentList()
		{
			//Chơi Ngoo
			//Student s1, s2, s3, s4, s5, s6, s7, s8,... 
			Student[] arr1 = new Student[30000];
			//					s1, s2, s3, s4, ....s30
			//arr má mì có 30 biến
			//arr.length
			//arr[0]. có xổ gì ko?

			//arr[0[ arr[1]... chính là từng biến sv lẻ, nay về ở chung vùng RAM bị  biến mảng arr má mì quản lí
			//Lợi gì: for nhanh tất cả các biến
			//Ko chơi mảng, thì phải gọi tên từng biến s1. s2. s3. s4
			//giờ chỉ là arr[i]. for i thoải mái luôn
			arr1[0] = new Student() { Id = "SE1", Name = "An", Yob = 2004, Gpa = 8.8 };

			arr1[1] = new Student() { Id = "SE2", Name = "Binh", Yob = 2003, Gpa = 5.2 };

			Student s2 = new Student() { Id = "SE2", Name = "Binh" };

			arr1[2] = arr1[0];
			arr1[2].ShowProfile();   //AN FOR SURE
			Console.WriteLine();


			//BTVN: HÃY LƯU GIÙM TÔI THÊM 5 - 10 SINH VIÊN VỚI ĐIỂM LỘN XỘN THỨ TỰ
			//		IN RA DANH SÁCH SINH VIÊN
			//		SẮP XẾP DANH SÁCH SINH VIÊN THEOO ĐIỂM TĂNG DẦN
			//		VÀ IN RA MÀN HÌNH

			Student[] arr = new Student[10];        //Có 10 biến Student riêng lẻ, dc khai báo nhanh

			arr[0] = new Student() { Id = "SE1", Name = "An" };
			arr[1] = new Student() { Id = "SE2", Name = "Binh", Yob = 2004, Gpa = 5.0 };
			arr[2] = new Student() { Id = "SE3", Name = "Chau", Yob = 2002, Gpa = 6.9 };
			arr[3] = new Student() { Id = "SE4", Name = "Dung", Yob = 2001, Gpa = 7.4 };
			arr[4] = new Student() { Id = "SE5", Name = "Em", Yob = 2000, Gpa = 4.8 };
			arr[5] = new Student() { Id = "SE6", Name = "Phong", Yob = 1999, Gpa = 9.1 };
			arr[6] = new Student() { Id = "SE7", Name = "Hung", Yob = 2005, Gpa = 6.1 };
			arr[7] = new Student() { Id = "SE8", Name = "Minh", Yob = 2003, Gpa = 8.4 };
			arr[8] = new Student() { Id = "SE9", Name = "Son", Yob = 1998, Gpa = 9.0 };
			arr[9] = new Student() { Id = "SE10", Name = "Vuong", Yob = 2005, Gpa = 5.5 };

			Console.WriteLine("Danh sách sinh viên:");
			foreach (Student student in arr)
			{
				student.ShowProfile();
			}
			Console.WriteLine();

			Console.WriteLine("Sap xep danh sách sinh vien theo diem tang dan");
			for (int i = 0; i < arr.Length - 1; i++)
			{
				for (int j = i + 1; j < arr.Length; j++)
				{
					if (arr[i].Gpa > arr[j].Gpa)
					{
						Student temp = arr[i];
						arr[i] = arr[j];
						arr[j] = temp;
					}
				}
			}

			foreach (Student stu in arr)
			{
				stu.ShowProfile();
			}
		}

		static void CreateStudent()
		{
			Student s1 = new Student(); //default contructor
										//default _backing field
			s1.Id = "SE1";  //hàm Set() đó
			s1.Name = "An";

			s1.ShowProfile();

			Student s2 = new Student()      //Object-Initializer
			{
				Id = "SE2",
				Name = "Binh"
			};
			s2.ShowProfile();
		}

	}
}

//CHỐT HẠ:
//Mảng primited, chỉ có 2 tầng RAM
//Tầng 1 biến má mì
//Tầng 2 dãy biến trong mảng [0] [1] [2]....
//Nếu mảng ko được gán hết value cho các phần tử/biến [i]
//Thì biến mảng giá trị Default: số là 0, Bool là Sai
//In thoải mái, for hết hàng okie luôn, lẫn lộn cừa giá trị thật và giá trị default

//Mảng obj4ct, có 3 tầng RAM
//Tàng 1 biến má mì
//Tầng 2 dãy biến trong hằng, và là biến object, đang chờ để chờ tiếp vùng nw Student() thật sự
//[0] [1] [2] đang chờ = new Student()

//Nếu chưa gán hết hàng, thì biến thứ [1=i] cũng mang default, default biến object là null. Rất nguy hiểm nếu for hết mảng mà  mảng chưa đầy, thì gặp null ở [i], mà nếu [i] gọi hàm của  object thì bị Reference exception

//CHỐT HẠ:
//KO NÊN FOR HẾT MẢNG DÙ MẢNG LÀ PRIMITIVE HAY OBJECT DO PHẦN CHỨA GÁN LÀ DEFAULT, ĐẶC BIỆT MẢNG OBJECT COI CHỪNG EXCEPTION
//
//Để in mảng ta có 2 cách
//1. Cách 1: For đến chỗ đã gán value

//2. Cách 2: Cứ for hết với mảng object, nhưng kiểm tra if ([i] == null hay ko để gọi hàm vùng new

//Cách 1 tốt hơn, do ko cần for phí ở đoạn cuối
//Khi chơi mảng, ta cần thêm 1 biến phụ count, count ban đầu = 0, cú gán xong 1 value cho biến [count] cộng ngay count++
//COUNT 0, [0] = .....;
//COUNT++ 1 [1] = .....;
//COUNT++2 [2] = ....;

//CHỐT HẠ VỀ DẤU CHẤM:
//Tên mảng, má mì chấm thì xổ ra Length (Ko care loại mảng)

//Mảng primitive, [i] chấm vô nghĩa, vì biến primitive[i] có value luôn mà dùng, 5 10 15 20

//Mảng object thì [i] chấm xổ ra các method, property của object, của vùng new()