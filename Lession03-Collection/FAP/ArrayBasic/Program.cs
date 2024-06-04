namespace ArrayBasic
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PlayWithIntegerListV4();
		}

		//CHALLENGE 1: HÃY LƯU TRỮ DÃY SỐ 5 10 15 20 25 30 35 40 45 50,....VÀ IN RA MÀN HÌNH

		static void PlayWithIntegerListV4()
		{
			int[] arr = { -10, -5 , 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
			//in mảng
			Console.WriteLine($"{arr[0]} {arr[1]} {arr[2]} {arr[3]} {arr[4]} {arr[5]} {arr[6]} {arr[7]} {arr[8]} {arr[9]}");

			//Vì các biến lẻ trong mảng dùng chỉ số [0].....để phân biệt; 0 1 2 3 4...tăng dần => VÒNG LẬP, MẢNG CHƠI VỚI LẶP
			Console.WriteLine("The list of 5 10... (printed by using for i)");
			for (int i = 0; i < arr.Length; i++)
			{
				Console.Write($"{arr[i]} ");
            }
			//Sống có trách nhiệm, xuống hàng
			Console.WriteLine();
            Console.WriteLine("The list of 5 10....(printed by using for each)");
            foreach (int x in arr)
            { //toán tử với mọi x thuộc tập số N arr
              //x là 1 con số nguyên có quyền mang giá trị
              //là x = arr[0], x = arr[1], x = arr[2]...
                Console.Write(x + " ");
            }
			Console.WriteLine();

			foreach (var x in arr)
            { //x chính là 1 con int do nó ứng với arr[i], mảng nguyên
                Console.Write($"{x} ");
            }

			//select * from table Student where province in {N"Bình Dương", "Đồng Nai", "Bình Phước"}
        }

		static void PlayWithIntegerListV3()
		{
			int[] arr = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
			//			  new ngầm new int [10]

			//[] nhiều biến int
			//				[0] [1] [2] [3]....
			//				các biến int như bt kèm theo value
			//				int x = 5, x được gọi tên mới là arr
			//				tên biến lẻ nay hơi dài về tên 1 chút
			// arr là BIẾN MÁ MÌ QUẢN LÝ DƯỚI TAY, DƯỚI TRƯỚNG 10 EM BIẾN IN LẺ [0] [1] [2]
			// ARR LÀ BIẾN CON TRỎ TRỎ VÙNG NEW BỰ CHỨA 10 BIẾN INT
			//Vậy arr có quyền chấm để đi vào vùng New
			//Arr là biến object, vì trỏ vùng new bự phức tạp
			//					  Vì vùng New bự có 10 biến int
			// Mảng là biến tham chiếu luôn

		}

		static void PlayWithIntegerListV2()
		{
			//CÁCH HIỆN ĐẠI, HIỆU QUẢ - KHAI BÁO SỈ - CÚ PHÁP CÁCH VIẾT SẼ RỐI HON 1 CHÚT
			int a = 5, b = 10, c = 15, d = 20;  //....

			int[] arr1 = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };     //New ngầm, arr1 = new int[10]

			int[] arr2 = [5, 10, 15, 20, 25, 30, 35, 40, 45, 50];       //New ngầm luôn

			int[] arr3 = new int[10] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };

			int[] arr4 = new int[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };

			int[] arr5 = new int[10];
			//					Có 10 biến int riêng lẻ nhưng được khai báo nhanh = 1 câu lệnh
			//	10 Biến int này là: arr5[0] arr5[1] arr5[2] ....
			arr5[0] = 5;
			arr5[1] = 10;
			arr5[2] = 15;
			arr5[3] = 20;
			arr5[4] = 25;
			arr5[5] = 30;

			//KHA BÁO MẢNG: MẢNG CHỈ LẢ KỸ THUẬT KHAI BÁO NHIỀU BIẾN (KHAI BÁO SỈ)
			//CÙNG 1 LÚC, CÙNG 1 KIỂU, CÙNG 1 TÊN, Ở SÁT NHAU TRONG RAM

			//Khai báo mảng là khai báo nhiều biến chứa nhiều giá trị trong RAM
			//Một cách nhanh gọn hiệu quả

			//Do mảng là đai diện cho nhiều biến trùng tên trùng kiểu,do đó để
			//Phân biệt từng biến lẻ, ta dùng [Index đếm từ 0]

			//Biến thứ [0] biến thứ [1] biến thứ [2]

			//Có 3 thứ cần lưu ý khi chơi mảng
			//Tên mảng
			//New [] New ngoặc vuông
			//...
		}

		static void PlayWithIntegerListV1()
		{
			//CÁCH TRUYỀN THỐNG KIỂU TRÂU BÒ - Khai báo lẻ, biến lẻ, biến rời rạc, từng biến 1
			//Biến: tên gọi cho value nào đó
			//int a, b, c, d, e, f, g, h, i, j;
			//a = 5; b = 10; c = 15; d = 20;
			//e = 25; f = 30; g = 35; h = 40; i = 45; j = 50;

			int a = 5, b = 10, c = 15, d = 20, e = 25, f = 30, g = 35, h = 40, i = 45, j = 50;

			//in ra màn hình
			Console.WriteLine("The list of 5 10 15.....");
			Console.WriteLine($"{a}, {b}, {c}, {d}, {e}, {f}, {g}, {h}, {i}, {j}");


		}
	}
}
