namespace OOP
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Car car = new Car();
            car.PlateNumber = "51X9-12345";
            

            Car.Wheel wheel = new Car.Wheel(car);
            wheel.Print();
            car.Run(3); // Mode 3 - velocity 60
            car.Run(550.0); //Run with velocity 550 km/h
            

            Car car1 = new Electriccar("SN12345", "51X9-12345", 60, 20000); // car1 ở stack, car1.serialNumber ở Heap

            car.StartEngine(); // xe xang // xe điện
            car1.StartEngine();
            //Console.WriteLine(car1.ToString());
        }
        class Car
        {
            private string serialNumber;
            protected string plateNumber; // Field - Heap: vì nó đc tạo ra khi thực hiện toán tử new
            public List<Wheel> Wheels { get; set; } // property - thuộc tính
            public Car()
            {

            }
            public Car(string serialNumber, string plateNumber, int wheelSize)
            {
                this.serialNumber = serialNumber;
                this.plateNumber = plateNumber;
                this.Wheels = new List<Wheel>();
                Wheel wheel1 = new Wheel(this);
                wheel1.WheelSize = wheelSize;
                this.Wheels.Add(wheel1);
            }
            public string PlateNumber
            {
                get { return plateNumber; }
                set { plateNumber = value; }
            }
            
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
                    string pn; //variable : stack
                    Console.WriteLine($"WheelSize: {0} cm of car with platenumber {1}", WheelSize, _owner.plateNumber);
                }
                
            }
            //Demo overload
            /// <summary>
            /// Run car with mode
            /// </summary>
            /// <param name="mode">Value from 1 to 5</param>
            public void Run(int mode)
            {
                Console.WriteLine("Car is running in mode {0} with velocity {1} km/h",mode, mode * 20);
            }
            public void Run(double velocity)
            {
                Console.WriteLine("Car is running in mode {0} with velocity {1} km/h",  Math.Floor(velocity / 3), velocity);
            }

            // Demo override
            public virtual void StartEngine() //virtual cho phép override
            {
                Console.WriteLine("Turn on!");
                Console.WriteLine("Engine warn up!");
                Console.WriteLine("Engine Ready1"); ;
            }
        }

        class Electriccar : Car
        {
            public int PinCapacity { get; set; }
            public Electriccar(string serialNumber, string plateNumber, int wheelSize, int pinCapacity)
                : base(serialNumber, plateNumber, wheelSize)
            {
                this.PinCapacity = pinCapacity;
            }

            // Demo override
            public override void StartEngine() // phải có override mới báo tín hiệu ghi đè
            {
                Console.WriteLine("Turn on and Engine ready!!!"); ;
            }
        }

        class Ferry
        {
            public void Take()
            {

            }
            public void PassRive()
            {

            }
        }
        interface IVehicle
        {
            void Run();
        }
        class Bike : IVehicle 
        {
            public string plateNumber;

        }

    }
}
/*
4 characistics of OOP: Encapsulation (Bao đóng), Inheritance, Polymorphism (Đa hình), Abstraction
    1. Encapsulation: đóng gói các thành phần vào 1 đơn vị, chỉ public chọn lọc
        //System (Server-Client...) ==> Software ==> Package ==> Class ==> Attribute + Method    
    2. Kế thừa    
    3. Đa hình: overload, override (mqh cha con)
        cùng 1 đối tượng, 1 method nhwung nó có hành vi khác nhau tùy vào cách chúng ta khai báo nó
    4. Khái quát hóa
    
SOLID: Nguyên lý thiết kế  - cách developer nên tuân thủ khi thiết kế
-> thông dụng trong phát triển phần mềm OOP
SOLID (slide)
mỗi package chỉ nên làm những nhiệm vụ liên quan đến nhau

 */