namespace Smart_Parking_System_Async_Await_Assignment
{
	class Program
	{
		static async Task Main(string[] args)
		{
			SmartParkingSystem parking = new SmartParkingSystem();
			List<string> car = new List<string>() { "A123", "A333", "A321" };

			Console.WriteLine("Smart Parking System is starting...\n");

			foreach (string carItem in car)
			{
				await parking.CarEnterAsync("A123");
			}

			await Task.Delay(5000);

			foreach (string carItem in car)
			{
				await parking.CarExitAsync("A123");
			}

			Console.WriteLine("Parking system transaction completed!\n");
		}
	}
}
