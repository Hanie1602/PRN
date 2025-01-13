using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPChatServerandClient
{
	public class ChatServer
	{
		private TcpListener _listener;
		private List<TcpClient> _clients = new List<TcpClient>();

		public void StartServer(int port)
		{
			_listener = new TcpListener(IPAddress.Any, port);
			_listener.Start();
			Console.WriteLine("Máy chủ đã khởi động trên cổng (port)");

			while (true)
			{
				TcpClient client = _listener.AcceptTcpClient();
				_clients.Add(client);
				Console.WriteLine("Đã kết nối máy khách mới");

				Thread clientThread = new Thread(HandleClient);
				clientThread.Start();
			}
		}

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
						break;

					string message = Encoding.UTF8.GetString(b, 0, byteRead);
					Console.WriteLine($"Đã nhận: {message}");
					BroadcastMessage(message, client);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Lỗi máy khách: {ex.Message}");
			}
			finally
			{
				_clients.Remove(client);
				client.Close();
			}
		}

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

//Khởi động server, lắng nghe máy khách
//Xử lý nhiều máy khách đồng thời
//Phát tin nhắn từ 1 máy khách đến nhiều máy khách khác