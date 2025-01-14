using System.Net.Sockets;
using System.Text;

namespace TCPChatServerandClient
{
	public class ChatClient
	{
		private TcpClient _client;

		public void ConnectToServer(string ipServer, int port)
		{
			_client = new TcpClient(ipServer, port);
			Console.WriteLine("Conned to Server");

			Thread readThread = new Thread(ReadMessage);
			readThread.Start();

			while (true)
			{
				string message = Console.ReadLine();
				SendMessage(message);
			}
		}

		private void SendMessage(string message)
		{
			try
			{
				if (_client != null && _client.Connected)
				{
					byte[] data = Encoding.UTF8.GetBytes(message);
					NetworkStream stream = _client.GetStream();
					stream.Write(data, 0, data.Length);
				}
				else
				{
					Console.WriteLine("Disconnected from server.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error sending message: {ex.Message}");
			}
		}

		private void ReadMessage()
		{
			try
			{
				NetworkStream stream = _client.GetStream();
				byte[] buffer = new byte[1024];

				while (true)
				{
					int byteRead = stream.Read(buffer, 0, buffer.Length);
					if (byteRead == 0)
						break;

					string message = Encoding.UTF8.GetString(buffer, 0, byteRead);
					Console.WriteLine($"Server: {message}");
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Error reading message: {ex.Message}");
			}
		}
	}
}
