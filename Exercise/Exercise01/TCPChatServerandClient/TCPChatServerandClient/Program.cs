using TCPChatServerandClient;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Choose mode: [1] for Server, [2] for Client");
		string mode = Console.ReadLine();

		if (mode == "1")
		{
			ChatServer server = new ChatServer();
			server.StartServer(5000);
		}
		else if (mode == "2")
		{
			ChatClient client = new ChatClient();
			Console.WriteLine("Enter Server IP (default: 127.0.0.1): ");
			string serverIp = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(serverIp)) serverIp = "127.0.0.1";

			client.ConnectToServer(serverIp, 5000);
		}
		else
		{
			Console.WriteLine("Invalid option.");
		}
	}
}