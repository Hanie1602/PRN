// See https://aka.ms/new-console-template for more information
using LeaderboardsDuongLntWCFServiceRef;
using System.ServiceModel;

Console.WriteLine("Attempting to connect to SOAP service using ChannelFactory...");

//  Create the communication channel (the client proxy).
ILeaderboardsDuongLntSoapService leaderboardsDuongLntSoapService = new LeaderboardsDuongLntSoapServiceClient(LeaderboardsDuongLntSoapServiceClient.EndpointConfiguration.BasicHttpBinding_ILeaderboardsDuongLntSoapService);

try
{
	// 5. Call the method directly on the interface.
	var leaderboards = await leaderboardsDuongLntSoapService.GetLeaderboardsDuongLntAsync();

	Console.WriteLine("1. GetAll: ");
	var leaderboadsJsonString = System.Text.Json.JsonSerializer.Serialize(leaderboards);
	Console.WriteLine(leaderboadsJsonString);
	Console.WriteLine("2. GetById: ");
	var leaderboard = await leaderboardsDuongLntSoapService.GetLeaderboardsDuongLntByIdAsync(2);
	var leaderboardJsonString = System.Text.Json.JsonSerializer.Serialize(leaderboards);
	Console.WriteLine(leaderboardJsonString);
}
catch (Exception e)
{
	Console.ForegroundColor = ConsoleColor.Red;
	Console.WriteLine($"\nAn error occurred: {e.Message}");
	Console.ResetColor();
	Console.WriteLine("Please ensure the SOAP API project is running.");
}
finally
{
	// 6. Always close the channel to free up resources.
	if (leaderboardsDuongLntSoapService is IClientChannel clientChannel && clientChannel.State == CommunicationState.Opened)
	{
		clientChannel.Close();
	}
}
Console.WriteLine("\nPress any key to exit.");
Console.ReadKey();