using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SSLAndTLS
{
	public class SecureTcpClient
	{
		private static readonly string ServerAddress = "localhost";
		private static readonly int Port = 5000;

		public static async Task RunClient()
		{
			try
			{
				using (TcpClient client = new TcpClient(ServerAddress, Port))
				using (NetworkStream networkStream = client.GetStream())
				using (SslStream sslStream = new SslStream(networkStream, false, ValidateServerCertificate))
				{
					await sslStream.AuthenticateAsClientAsync(ServerAddress);
					Console.WriteLine("Connected securely to the server!");

					string message = "Hello Secure Server!";
					byte[] data = Encoding.UTF8.GetBytes(message);
					await sslStream.WriteAsync(data, 0, data.Length);

					byte[] buffer = new byte[1024];
					int bytesRead = await sslStream.ReadAsync(buffer, 0, buffer.Length);
					string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
					Console.WriteLine($"Received: {receivedMessage}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		private static bool ValidateServerCertificate(object sender, X509Certificate? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors)
		{
			if (sslPolicyErrors == SslPolicyErrors.None)
				return true;

			Console.WriteLine($"SSL Certificate Error: {sslPolicyErrors}");
			return false;
		}
	}
}
