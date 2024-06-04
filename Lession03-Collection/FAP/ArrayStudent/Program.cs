using ArrayStudent.Entities;

namespace ArrayStudent
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//CreateStudent();
			PlayWithStudentList();
		}

		//CHALLENGE #2: HÃY LƯU THÔNG TIN, HỒ SO7CU3A 330 BẠN SINH VIÊN TRONG PHÒNG NÀY
		//Giải pháp 1
		//Chơi Ngoo: khai báo 30 biến student
		//chơi hiện đại: khai báo mảng


		static void PlayWithStudentList()
		{
			//Chơi Ngoo
			//Student s1, s2, s3, s4, s5, s6, s7, s8,... 
			Student[] arr = new Student[30000];
			//					s1, s2, s3, s4, ....s30
			//arr má mì có 30 biến
			//arr.length
			//arr[0]. có xổ gì ko?

			//arr[0[ arr[1]... chính al2 từng biến sv lẻ, nay về ở chung vùng RAM bị  biến mảng arr má mì quản lí
			//Lợi gì: for nhanh tất cả các biến
			//Ko chơi mảng, thì phải gọi tên từng biền s1. s2. s3. s4
			//giờ chỉ là arr[i]. for i thoải mái luôn
			arr[0] = new Student() { Id = "SE1", Name = "An", Yob = 2004, Gpa = 8.8};

			arr[1] = new Student() { Id = "SE2", Name = "Binh", Yob = 2003, Gpa = 5.2};

			Student s2 = new Student() { Id = "SE2", Name = "Binh" };

			arr[2] = arr[0];
			arr[2].ShowProfile();	//AN FOR SURE

			//BTVN: HÃY LƯU GIÙM TÔI THÊM 5 - 10 SINH VIÊN VỚI ĐIỂM LỘN XỘN THỨ TỰ
			//		IN RA DANH SÁCH SINH VIÊN
			//		SẮP XẾP DANH SÁCH SINH VIÊN THEOO ĐIỂM TĂNG DẦN
			//		VÀ IN RA MÀN HÌNH

        }

		static void CreateStudent()
		{
			Student s1 = new Student(); //default contructor
										//default _backing field
			s1.Id = "SE1";  //hàm Set() đó
			s1.Name = "An";

			s1.ShowProfile();

			Student s2 = new Student()		//Object-Initializer
			{
				Id = "SE2",
				Name = "Binh"
			};
			s2.ShowProfile();
		}
	}
}
