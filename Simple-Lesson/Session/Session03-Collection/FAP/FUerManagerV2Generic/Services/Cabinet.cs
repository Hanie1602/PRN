using FUerManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUerManagerV2Generic.Services
{
	public class Cabinet<T>		//T: data type
								//Hãy đưa kiểu dữ liệu vào đi, Student, Lecturer, Tiger, Lion, Dog, Cat, Sales, Staff...
								//LẦN ĐẦU TIÊN, DATA TYPE ĐƯỢC XEM LÀ 1 THAM SỐ LUÔN!!!!
								//CLASS làm việc với nhiều loại data type khác nhau!!!! -> <> Gọi là Generic
								//T: là 1 biến mà value của nó là data type, thay vì là 5 10 15 20
	{
		private T[] _arr1;
		private int _count1 = 0;

		//Code còn lại dựa trên T
		public Cabinet(int size) => _arr1 = new T[size];
		public void Add(T item) => _arr1[_count1++] = item;
		public void PrintAll()
		{
            Console.WriteLine($"\nThere is/are {_count1} item(s) in the cabinet");
			for(int i = 0; i < _count1; i++)
				Console.WriteLine(_arr1[i]);	//Gọi thầm tên em
			//Ko thể gọi ShowProfile() được, vì đâu biết class đưa vào là class gì
			//Gọi ToString() để in info bên trong object hoặc in ra kiểu dữ liệu của object!!!
        }

		//Cách xài Cabinet<Student>
		//			Cabinet<Lecturer>	//data type được đưa vào, như tham số
		//					data type là value!!!!!!!!!!!!!!!!!

		//Nghe mùi quen quen, List<Student> bên Java
	}
}


//BÌNH LUẬN:
//GENERIC Tuyệt vời khi giúp Class chúng ta làm việc được với nhiều Class khác bên trong nó, Class Cabinet có thể làm việc với, xử lý các object, mảng object của nhiều loại data type khác.

//Tuy nhiên, nó chơi với mảng, và mảng thì dễ dùng, nhưng ko linh hoạt
//Màng: bị Fixed kích  thước, mảng là khai báo nhiều biến
//		Nhiều, nhưng phải chi ra bao nhiêu biến
//		Một khi đã chỉ ra bao nhiêu biến thì ko thể xin thêm
//		Muốn xin thêm, xin mảng mới, new mảng mới

//									và phải copy value của mảng cũ sang mảng mới!!!!

//Mảng thì phải đi kèm biến count!!!! để đếm số phần tử đã có value!!!

//Và COLLECTION XUẤT HIỆN, VÀ LIST, ARRAYLIST, SET.... XUẤT HIỆN
//Đây là những "mảng" co giãn kích thước, số phần tử!!!
//Vùng New mà có thể nở thêm các biến bên trong!!
//Cần thêm, cho thêm, cần bớt, bớt luôn

//Và chúng nó có chơi với Generic, vùng new List<> có chơi Generic, chứa nhiều object của các Class khác nhau!!!
