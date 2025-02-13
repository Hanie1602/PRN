/*
- Kỹ thuật lập trình 3 nhanh 2 chậm
		○ Thread - dùng trong CPU
		○ Hàm, chức năng, thu hồi bộ nhớ,… - dùng trong RAM (có bộ nhớ Heap & Stack)
		○ Thiết kế DB, file - dùng trong ổ cứng
		○ Net work


- 4 chracteristics: Encapsulation, Inheritance, Polymorphism, Abstract

1. Encapsulation: 

System => Sofware ==> Package ==> Class ==> Attribute + Method

SOLID: Nguyên tắc thiết kế

- Ở cấp độ hệ thống chỉ quan tâm có bao nhiêu phần mềm
>> Muốn vẽ kiến trúc phần mềm thì vẽ mô hình MVC
>> Kiến trúc SOA (kiến trúc dịch vụ) 
>> Kiến trúc Microservice (chỉ chứa những service nhỏ)

- Ở cấp độ phần mềm chỉ quan tâm có bao nhiêu package (vẽ những package này có những package con nào, ví dụ: package service, package controller,....sâu trong các package có những package nào,...)

- Ở kiến trúc package thì có những class


** Đặc tính bao đóng là những thứ mà chúng ta cần thấy, ko cần 
 */

using System.Diagnostics.Contracts;

Car car = new Car();
car.PlateNumber = "53X9-12345";

Car.Wheel wheel = new Car.Wheel(car);
wheel.Print();

car.Run(3);  //Mode 3 - velocity = 60km/h
car.Run(550);   //Run with velocity = 55km/h

int a = 3;
Car electricCar = new ElectricCar("SN123456", "53X9 - 12345", 60, 20000);
int b = 5;

car.StartEngine(); //Xe xăng
electricCar.StartEngine();  //Xe điện

//Ferry ferry = new Ferry();
//ferry.Take(new Bike());
//ferry.Take(new Bike());
//ferry.Take(new Car());
//ferry.Take(new ElectricCar("a", "b", 4, 20000));

class Car
{
	private string seriaNumber;
	protected string plateNumber; //Field: trường dữ liệu - Heap

	public Car()
	{

	}

	public Car(string serialNum, string plateNum, int wheeelSize)
	{
		this.seriaNumber = serialNum;
		this.plateNumber = plateNum;
		for (int i = 0; i < 4; i++)
		{
			Wheel wheel1 = new Wheel(this);
			wheel1.WheelSize = wheeelSize;
			this.Wheels.Add(wheel1);
		}
	}

	public string PlateNumber
	{
		get { return plateNumber; }
		set { plateNumber = value; }
	}

	public virtual void StartEngine()
	{
		Console.WriteLine("Turn on!");
		Console.WriteLine("Engine Warmup!");
		Console.WriteLine("Engine Ready!");

	}

	public List<Wheel> Wheels { get; set; } //Propety: thuộc tính

	public class Wheel
	{
		private Car _owner;
		public int WheelSize { get; set; }

		public Wheel(Car owner)
		{
			_owner = owner;
		}

		public void Print()
		{
			string pn; //variable: Stack
			Console.WriteLine("WheelSize: {0}cm of car with platnumber {1}", WheelSize, _owner.plateNumber);
		}
	}

	//Demo Overload
	/// <summary>
	/// Run car with mode
	/// </summary>
	/// <param name="mode">Value from 0 to 5</param>
	public void Run(int mode)
	{
		Console.WriteLine("Car is running in mode {0} with velocity {1}km/h", mode, mode * 20);
	}

	public void Run(double velocity)
	{
		Console.WriteLine("Car is running in with velocity {0}km/h", velocity);
	}
}

//Kế thừa:
//>> Con kế thừa toàn bộ từ cha (kể cả private)
//>> Tiết kiệm được số lượng code
//>> Tăng độ tin tưởng, tiết kiệm được tăng trưởng
// Khi tạo ra 1 class cha, th con kế thừa từ cha, thì th con có thể Override được, hoặc có thể kế thừa từ cha
class ElectricCar : Car
{
	public int Pincapacity { get; set; }

	public ElectricCar(string serialNum, string plateNum, int wheelSize, int pinCapacity) : base(serialNum, plateNum, wheelSize)
	{
		this.Pincapacity = pinCapacity;
	}

	//Có override mới báo ghi đè
	public override void StartEngine()
	{
		Console.WriteLine("Turn on and engine ready!!");

	}
}

/*Đa hình:
- Cùng 1 đối tượng nhưng có thành viên khác nhau, phụ thuộc vào cách mà chúng ta khai báo nó
- Overload: là các hàm cùng tên, cùng chức năng, để cho dễ hiểu
- Override: class con để từ khóa override, class cha để từ khóa virtual
*/

// Khái quát hóa
class Ferry
{
	List<IVehicle> vehicles = new List<IVehicle>();
	public void Take(IVehicle vehicle)
	{
		vehicles.Add(vehicle);
	}

	public void PassRiver()
	{
		foreach(var item in vehicles)
		{
			item.Run();
		}
	}

}

interface IVehicle
{
	void Run();
}

