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
				await parking.CarEnterAsync(carItem);

				await Task.Delay(5000);

				await parking.CarExitAsync(carItem);
			}

			Console.WriteLine("Parking system transaction completed!\n");
		}
	}
}

/* Note:
 * [1] Mutex: Mutual exclisive
 * object Labor = new lock()
 * => Nếu 1 th` có lock rồi thì người tiếp theo phải chờ
 * 
 * Network Programming => Lập trình bất đồng bộ Sync & Async => Lập trình song song Parallel
 */