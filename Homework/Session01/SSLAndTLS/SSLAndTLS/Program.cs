namespace SSLAndTLS
{
	public class Program
	{
		public static async Task Main()
		{
			Console.WriteLine("Choose option:");
			Console.WriteLine("[1] Run Server");
			Console.WriteLine("[2] Run Client");
			Console.Write("Enter: ");

			string? choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					Console.WriteLine("Server is starting...");
					await SecureTcpServer.RunServer();
					break;
				case "2":
					Console.WriteLine("Client is starting...");
					await SecureTcpClient.RunClient();
					break;
				default:
					Console.WriteLine("Invalid selection! Please enter 1 or 2.");
					break;
			}
		}
	}
}
