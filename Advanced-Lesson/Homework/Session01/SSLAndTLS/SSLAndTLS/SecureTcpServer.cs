using System.Net.Security;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SSLAndTLS
{
	public class SecureTcpServer
	{
		private static readonly int Port = 5000;
		private static readonly string CertPath = @"D:\Github\PRN212\Homework\Session01\server.pfx";
		private static readonly string Password = "333";   //Mật khẩu chứng chỉ

		public static async Task RunServer()
		{
			X509Certificate2 certificate = new X509Certificate2(CertPath, Password);
			TcpListener listener = new TcpListener(IPAddress.Any, Port);
			listener.Start();
			Console.WriteLine($"Secure TCP Server running on port {Port}...");

			while (true)
			{
				TcpClient client = await listener.AcceptTcpClientAsync();
				await Task.Run(() => HandleClient(client, certificate));
			}
		}

		private static async Task HandleClient(TcpClient client, X509Certificate2 certificate)
		{
			Console.WriteLine("Client connected.");
			using (NetworkStream networkStream = client.GetStream())
			using (SslStream sslStream = new SslStream(networkStream, false))
			{
				try
				{
					await sslStream.AuthenticateAsServerAsync(certificate, false, System.Security.Authentication.SslProtocols.Tls12, true);
					Console.WriteLine("SSL/TLS handshake successful!");

					byte[] buffer = new byte[1024];
					int bytesRead = await sslStream.ReadAsync(buffer, 0, buffer.Length);
					string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
					Console.WriteLine($"Received: {receivedMessage}");

					string response = "Hello from Secure Server!";
					byte[] responseData = Encoding.UTF8.GetBytes(response);
					await sslStream.WriteAsync(responseData, 0, responseData.Length);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"SSL Error: {ex.Message}");
				}
			}
			client.Close();
		}
	}
}
