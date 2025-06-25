using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUerManager.Services
{
	public class Cabinet<T> //Lần đầu tiên Data type được đưa vào như là tham số, class chơi với nhiều loại data type khác
	{
		//private T[] _arr;
		//private int _count = 0;
		private List<T> _arr = new List<T>();
		//Túi ba gang, nồi cơm Thạch Sanh

		//public Cabinet(int size) => _arr = new T[size];
		//Đơn giản hơn so với mảng

		public void PrintItems()
		{
			//Kiểm tra nếu List ko có gì thì sao, mới mua tủ về, mở ra trống trơn
			if (_arr.Count == 0)
			{
				Console.WriteLine("The list is empty. Nothing to print");
				return;
			}

			Console.WriteLine($"There is/are {_arr.Count} item(s) in the cabinet");

			foreach (T x in _arr)
				Console.WriteLine(x); //Gọi thầm tên em
				//For i truyền thống vẫn okie
		}

		public void AddAnItem(T x) => _arr.Add(x);
	}
}
