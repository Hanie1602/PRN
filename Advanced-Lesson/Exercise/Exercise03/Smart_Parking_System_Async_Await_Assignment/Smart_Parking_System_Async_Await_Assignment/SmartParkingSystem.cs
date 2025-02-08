using System.Diagnostics;

class SmartParkingSystem
{
	//In thông tin về process và luồng hiện tại
	private void PrintThreadInfo(string methodName, string carNumber)
	{
		Process process = Process.GetCurrentProcess();
		Console.WriteLine($"[{methodName} - Car {carNumber}] ProcessId: {process.Id}, ThreadId: {Environment.CurrentManagedThreadId}, Total Threads: {process.Threads.Count}");
	}

	//Kiểm tra vé xe hợp lệ
	public async Task CheckTicketAsync(string carNumber)
	{
		PrintThreadInfo(nameof(CheckTicketAsync), carNumber);
		Console.WriteLine($"[Car {carNumber}] Checking ticket...");
		await Task.Delay(2000);
		Console.WriteLine($"[Car {carNumber}] Ticket is valid!");
	}

	//Mở rào chắn để xe đi vào
	public async Task OpenEntryBarrierAsync(string carNumber)
	{
		PrintThreadInfo(nameof(OpenEntryBarrierAsync), carNumber);
		Console.WriteLine($"[Car {carNumber}] Opening entry barrier...");
		await Task.Delay(1500);
		Console.WriteLine($"[Car {carNumber}] Entry barrier opened.");
	}

	//Tìm vị trí đỗ xe và đỗ xe
	public async Task ParkCarAsync(string carNumber)
	{
		PrintThreadInfo(nameof(ParkCarAsync), carNumber);
		Console.WriteLine($"[Car {carNumber}] Searching for a parking spot...");
		await Task.Delay(3000);
		Console.WriteLine($"[Car {carNumber}] Successfully parked.");
	}

	//Xử lý thanh toán
	public async Task ProcessPaymentAsync(string carNumber)
	{
		PrintThreadInfo(nameof(ProcessPaymentAsync), carNumber);
		Console.WriteLine($"[Car {carNumber}] Processing payment...");
		await Task.Delay(2000);
		Console.WriteLine($"[Car {carNumber}] Payment successful!");
	}

	//Mở rào chắn để xe đi ra
	public async Task OpenExitBarrierAsync(string carNumber)
	{
		PrintThreadInfo(nameof(OpenExitBarrierAsync), carNumber);
		Console.WriteLine($"[Car {carNumber}] Opening exit barrier...");
		await Task.Delay(1500);
		Console.WriteLine($"[Car {carNumber}] Exit barrier opened.");
	}

	//Cập nhật dữ liệu sau khi xe rời đi
	public async Task UpdateDatabaseAsync(string carNumber)
	{
		PrintThreadInfo(nameof(UpdateDatabaseAsync), carNumber);
		Console.WriteLine($"[Car {carNumber}] Updating database...");
		await Task.Delay(1000);
		Console.WriteLine($"[Car {carNumber}] Database updated.");
	}

	public async Task CarEnterAsync(string carNumber)
	{
		await CheckTicketAsync(carNumber);
		await OpenEntryBarrierAsync(carNumber);
		await ParkCarAsync(carNumber);
		Console.WriteLine($"[Car {carNumber}] Successfully parked.\n");
	}

	public async Task CarExitAsync(string carNumber)
	{
		await ProcessPaymentAsync(carNumber);
		await Task.WhenAll(OpenExitBarrierAsync(carNumber), UpdateDatabaseAsync(carNumber));
		Console.WriteLine($"[Car {carNumber}] Successfully exited.\n");
	}
}