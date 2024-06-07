using StudentManager.Entities;
using StudentManager.Services;

namespace StudentManager
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
		}
	}
}



//BÀI TẬP VỀ NHÀ: ASSIGMENT #2 TRÊN LMS - DEADLINE 10/06 TRƯỚC 15:00

//VIẾT THÊM BÊN MAIN() CÁI MENU IN RA
//1. THÊM MỚI: NHẬP BÀN PHÍM, NHỚ CONVERT TỪ CHUỖI SANG SỐ, KIỂU INTEGER.PARSEINT() -> HỎI CHATGPT
//2. IN
//3. XÓA SỬA GÌ ĐÓ (KO BẮT BUỘC)

//VIẾT THÊM TỦ ĐỰNG HỒ SƠ GIẢNG VIÊN: ID, NAME, YOB, SALARY,...

//HỌC GENERIC <> LIST<STUDENT>