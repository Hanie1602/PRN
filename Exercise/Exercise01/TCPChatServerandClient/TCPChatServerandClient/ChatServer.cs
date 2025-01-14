using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPChatServerandClient
{
	public class ChatServer
	{
		private TcpListener _listener;
		private List<TcpClient> _clients = new List<TcpClient>();

		//Khởi động Server và lắng nghe kết nối từ Client
		public void StartServer(int port)
		{
			//Lắng nghe các kế nối từ mọi địa chỉ IP trên port
			_listener = new TcpListener(IPAddress.Any, port);
			_listener.Start();
			Console.WriteLine($"Server started on port {port}");

			while (true)
			{
				TcpClient client = _listener.AcceptTcpClient();
				_clients.Add(client);
				Console.WriteLine("New client connted");

				//Truyển client vào Thread
				Thread clientThread = new Thread(HandleClient);
				clientThread.Start(client);
			}
		}

		//Xử lý nhiều máy khách đồng thời
		private void HandleClient(object obj)
		{
			TcpClient client = (TcpClient)obj;

			try
			{
				NetworkStream stream = client.GetStream();
				byte[] b = new byte[1024];

				while (true)
				{
					int byteRead = stream.Read(b, 0, b.Length);
					if (byteRead == 0)
					{
						Console.WriteLine("Client disconnected");
						break;
					}

					string message = Encoding.UTF8.GetString(b, 0, byteRead);
					Console.WriteLine($"Received: {message}");
					BroadcastMessage(message, client);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error client: {ex.Message}");
			}
			finally
			{
				_clients.Remove(client);
				client.Close();
				Console.WriteLine("Client connection closed");
			}
		}

		//Phát tin nhắn từ 1 máy khách đến nhiều máy khách khác
		private void BroadcastMessage(string message, TcpClient sender)
		{
			byte[] data = Encoding.UTF8.GetBytes(message);

			foreach(TcpClient client in _clients)
			{
				if(client != sender)
				{
					NetworkStream stream = client.GetStream();
					stream.Write(data, 0, data.Length);
				}
			}
		}
	}
}

