using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

class SecureTcpServer
{
	//Khởi động Server
	public static void StartServer()
	{
		//Lắng nghe port 5000 từ mọi IP
		TcpListener listener = new TcpListener(IPAddress.Any, 5000);
		listener.Start();
		Console.WriteLine("Server started on port 5000...");

		//Vòng lặp để chờ kết nối
		while (true)
		{
			//Chấp nhận kết nối
			TcpClient client = listener.AcceptTcpClient();

			//Xử lý Client trong 1 luồng riêng
			ThreadPool.QueueUserWorkItem(HandleClient, client);
		}
	}

	//Xử lý giao tiếp với Client
	static void HandleClient(object obj)
	{
		TcpClient client = (TcpClient)obj;
		X509Certificate2 serverCert = new X509Certificate2("server.pfx", "password");

		//Khởi tạo luồng SSL
		using (SslStream sslStream = new SslStream(client.GetStream(), false))
		{
			try
			{
				sslStream.AuthenticateAsServer(serverCert, false, System.Security.Authentication.SslProtocols.Tls12, true);
				Console.WriteLine("Client connected and SSL authentication successful.");

				StreamReader reader = new StreamReader(sslStream, Encoding.UTF8);
				StreamWriter writer = new StreamWriter(sslStream, Encoding.UTF8) { AutoFlush = true };

				//Nhận tin nhắn từ Client
				string message = reader.ReadLine();
				Console.WriteLine("Received: " + message);

				writer.WriteLine("Hello from server");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception: " + ex.Message);
			}
			finally
			{
				client.Close();
			}
		}
	}
}

class SecureTcpClient
{
	//Khởi động Client
	public static void StartClient(string serverName)
	{
		//Kết nối đến Server
		TcpClient client = new TcpClient(serverName, 5000);

		using (SslStream sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback((sender, certificate, chain, sslPolicyErrors) => true)))
		{
			try
			{
				//Xác thực Client
				sslStream.AuthenticateAsClient(serverName);
				Console.WriteLine("Connected to server with SSL.");

				StreamWriter writer = new StreamWriter(sslStream, Encoding.UTF8) { AutoFlush = true };
				StreamReader reader = new StreamReader(sslStream, Encoding.UTF8);

				writer.WriteLine("Hello from client");
				string response = reader.ReadLine();
				Console.WriteLine("Server response: " + response);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception: " + ex.Message);
			}
			finally
			{
				client.Close();
			}
		}
	}
}

class Program
{
	static void Main()
	{
		Console.WriteLine("Starting TCP Server...");
		SecureTcpServer.StartServer();

		// Console.WriteLine("Starting TCP Client...");
		// SecureTcpClient.StartClient("localhost");
	}
}