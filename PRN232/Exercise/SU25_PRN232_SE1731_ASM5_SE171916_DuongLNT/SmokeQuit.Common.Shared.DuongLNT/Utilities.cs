using System.Text.Json;

namespace SmokeQuit.Common.Shared.DuongLNT
{
	public static class Utilities
	{
		private static string loggerFilePath = Directory.GetCurrentDirectory() + @"\DataLog.txt";

		public static string ConvertObjectToJSONString<T>(T entity)
		{
			string jsonString = JsonSerializer.Serialize(entity, new JsonSerializerOptions
			{
				WriteIndented = false,
			});

			return jsonString;
		}

		public static void WriteLoggerFile(string content)
		{
			try
			{
				var path = Directory.GetCurrentDirectory();

				using (var file = File.Open(loggerFilePath, FileMode.Append, FileAccess.Write))
				using (var writer = new StreamWriter(file))
				{
					writer.WriteAsync(content);
					writer.FlushAsync();
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Error writing to log file: {ex.Message}");
			}
		}

	}
}
