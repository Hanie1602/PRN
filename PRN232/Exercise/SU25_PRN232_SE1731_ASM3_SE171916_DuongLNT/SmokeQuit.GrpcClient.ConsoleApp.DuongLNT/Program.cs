// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using SmokeQuit.GrpcServices.DuongLNT.Protos;

Console.WriteLine("Hello, World!");

using var channel = GrpcChannel.ForAddress("https://localhost:7262");

var clientLeaderboardsGRPC = new LeaderboardsDuongLntGRPC.LeaderboardsDuongLntGRPCClient(channel);

Console.WriteLine("\r\nclientLeaderboardsGRPC.GetAllAsync(EmptyRequest):");
var leaderboards = clientLeaderboardsGRPC.GetAllAsync(new EmptyRequest() { });
if(leaderboards != null && leaderboards.Items.Count > 0)
{
	foreach (var item in leaderboards.Items)
	{
		Console.WriteLine(string.Format("{0} - {1}", item.LeaderboardsDuongLntid, item.Note));
	}
}

Console.WriteLine("\r\nclientLeaderboardsGRPC.GetByIdAsync(new LeaderboardsDuongLntIdRequest() { LeaderboardsDuongLntid = 1003 }):");
var leaderboard = clientLeaderboardsGRPC.GetByIdAsync(new LeaderboardsDuongLntIdRequest() { LeaderboardsDuongLntid = 1003 });
Console.WriteLine(string.Format("{0} - {1}", leaderboard.LeaderboardsDuongLntid, leaderboard.Note));