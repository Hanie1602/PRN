using ListBasic.Entities;
using System.Collections;

namespace ListBasic
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//PlayWithArrayList();
			PlayWithList();
		}

		static void PlayWithList()
		{
			List<Student> arr = new List<Student>();
			//Java: List<Student> arr = new List<>();	ăn đòn, vì Anonymous Class
			//Java: List<Student> arr = new ArrayList<>();
			//Java: ArrayList<Student> arr = new ArrayList<>();

			arr.Add(new Student() { Id = "SE1", Name = "AN"});
			arr.Add(new Student() { Id = "SE2", Name = "Binh"});
			arr.Add(new Student() { Id = "SE3", Name = "Cuong", Yob = 2003});

			//3 biến con trỏ được sinh ra, 3 biến này trỏ 3 vùng news

            Console.WriteLine("The list of Students");
			for(int i = 0; i < arr.Count; i++)
			{
				//arr[i].ShowProfile();
				arr.ElementAt(i).ShowProfile();	//get(i) bên  Java
			}
        }

		//JAVA: List (abtract), ArrayList (concrete - cụ thể)
		//		List<Student> arr = new ArrayList<>();
		//	   ArrayList<Student> arr = new ArrayList<>();
		//CẤM KO ĐƯỢC NEW LIST() Vì nếu ngoan cố new List<>() thì sẽ bị đập vào mặt khoảng 20 hàm cần viết code @Override
		//KỸ THUẬT NÀY JAVA GỌI LÀ KỸ THUẬT ANONYMOUS CLASS - CLASS ẨN DANH

		//C#: KHÁC
		//ArrayList new ArrayList() ko có Generic!!!!!!!!!!!!!!!!!!!!!!!
		//NHA SĨ KHUYÊN KO NÊN DÙNG ARRAYLIST CỦA C#

		//C# KHÁC:
		//List<> là Generic
		//Và NEW LIST<> như bình thường, tức là LIST<> bên C# thay thế ngang bằng ARRAYLIST<> BÊN JAVA
		static void PlayWithArrayList()
		{
			ArrayList arr = new ArrayList();
			//RAM 1 vùng New bự dự kiến sẽ có nhiều biến khác được nhét vào
			//New ArrayList() - new int[];
			//Chừng nào gán value thì mới thêm biến tương ứng!!!!

			arr.Add(5);		//arr[0]=5;
			arr.Add(10);	//arr[1]=10;
			arr.Add(15);    //arr[2]=15;
			arr.Add(20);    //arr[3]=20;
			arr.Add("Phương Trinh");
			arr.Add(3.14);
			arr.Add(false);

			//Ko khuyên dùng vì lộn xộn data type
			//[i]. Ko biết nên xổ ra gì, vì lộn xộn cả object, và Primitive
			//Chưa kể lộn xộn object: Student, Lecturer, Pet,....
			//Mỗi object có chấm riêng của nó.

            //for tới bến!!!! Ko cần biến count, vì ko cấp dư vùng RAM cho các biến trong vùng new
            Console.WriteLine("The list of numbers");
			for (int i = 0; i < arr.Count; i++)		//arr.Size() bên Java
			{
				Console.WriteLine(arr[i]);			//arr.get(i) bên Java
            }


        }
	}
}
