using System;
using System.ServiceModel;
using System.Text.Json;
using LeaderboardsDuongLntWCFServiceRef;

class Program
{
	static async Task Main(string[] args)
	{
		var client = new LeaderboardsDuongLntSoapServiceClient(
			LeaderboardsDuongLntSoapServiceClient.EndpointConfiguration.BasicHttpBinding_ILeaderboardsDuongLntSoapService
		);

		bool running = true;
		while (running)
		{
			Console.Clear();
			Console.WriteLine("===== SOAP Leaderboards Menu =====");
			Console.WriteLine("1. Get All");
			Console.WriteLine("2. Get By ID");
			Console.WriteLine("3. Create");
			Console.WriteLine("4. Update");
			Console.WriteLine("5. Delete");
			Console.WriteLine("0. Exit");
			Console.Write("Select: ");
			string choice = Console.ReadLine();

			try
			{
				switch (choice)
				{
					case "1":
						var list = await client.GetLeaderboardsDuongLntAsync();
						Console.WriteLine(JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true }));
						break;

					case "2":
						Console.Write("Enter ID: ");
						int id = int.Parse(Console.ReadLine());
						var item = await client.GetLeaderboardsDuongLntByIdAsync(id);
						Console.WriteLine(JsonSerializer.Serialize(item, new JsonSerializerOptions { WriteIndented = true }));
						break;

					case "3":
						Console.Write("DaySmokeFree: ");
						int daySmokeFree = int.Parse(Console.ReadLine());

						Console.Write("MoneySave: ");
						double moneySave = double.Parse(Console.ReadLine());

						Console.Write("RankPosition: ");
						int rank = int.Parse(Console.ReadLine());

						Console.Write("TotalAchievements: ");
						int achievements = int.Parse(Console.ReadLine());

						Console.Write("ProgressScore (0.0 - 1.0): ");
						double progress = double.Parse(Console.ReadLine());

						Console.Write("Note: ");
						string note = Console.ReadLine();

						Console.Write("StreakCount: ");
						int streak = int.Parse(Console.ReadLine());

						Console.Write("CommunityContribution: ");
						int contribution = int.Parse(Console.ReadLine());

						Console.Write("IsTopRanked (true/false): ");
						bool isTop = bool.Parse(Console.ReadLine());

						var newItem = new LeaderboardsDuongLnt
						{
							UserId = 1,
							PlanId = 4,
							DaySmokeFree = daySmokeFree,
							MoneySave = moneySave,
							RankPosition = rank,
							TotalAchievements = achievements,
							ProgressScore = progress,
							Note = note,
							StreakCount = streak,
							CommunityContribution = contribution,
							IsTopRanked = isTop,
							LastUpdate = DateTime.Now,
							CreatedTime = DateTime.Now
						};


						var createdId = await client.CreateAsync(newItem);
						Console.WriteLine($"Create successed");
						break;

					case "4":
						Console.Write("Enter ID to update: ");
						int updateId = int.Parse(Console.ReadLine());

						var updateItem = await client.GetLeaderboardsDuongLntByIdAsync(updateId);
						if (updateItem == null || updateItem.UserId == 0)
						{
							Console.WriteLine("Item not found!");
							break;
						}

						Console.WriteLine($"Updating ID: {updateItem.LeaderboardsDuongLntid}");
						Console.WriteLine("Enter new values (leave empty to keep current):");

						Console.Write($"PlanId ({updateItem.PlanId}): ");
						string input = Console.ReadLine();
						if (!string.IsNullOrWhiteSpace(input))
							updateItem.PlanId = int.Parse(input);

						Console.Write($"DaySmokeFree ({updateItem.DaySmokeFree}): ");
						input = Console.ReadLine();
						if (!string.IsNullOrWhiteSpace(input))
							updateItem.DaySmokeFree = int.Parse(input);

						Console.Write($"MoneySave ({updateItem.MoneySave}): ");
						input = Console.ReadLine();
						if (!string.IsNullOrWhiteSpace(input))
							updateItem.MoneySave = double.Parse(input);

						Console.Write($"RankPosition ({updateItem.RankPosition}): ");
						input = Console.ReadLine();
						if (!string.IsNullOrWhiteSpace(input))
							updateItem.RankPosition = int.Parse(input);

						Console.Write($"TotalAchievements ({updateItem.TotalAchievements}): ");
						input = Console.ReadLine();
						if (!string.IsNullOrWhiteSpace(input))
							updateItem.TotalAchievements = int.Parse(input);

						Console.Write($"ProgressScore ({updateItem.ProgressScore}): ");
						input = Console.ReadLine();
						if (!string.IsNullOrWhiteSpace(input))
							updateItem.ProgressScore = double.Parse(input);

						Console.Write($"Note ({updateItem.Note}): ");
						input = Console.ReadLine();
						if (!string.IsNullOrWhiteSpace(input))
							updateItem.Note = input;

						Console.Write($"StreakCount ({updateItem.StreakCount}): ");
						input = Console.ReadLine();
						if (!string.IsNullOrWhiteSpace(input))
							updateItem.StreakCount = int.Parse(input);

						Console.Write($"CommunityContribution ({updateItem.CommunityContribution}): ");
						input = Console.ReadLine();
						if (!string.IsNullOrWhiteSpace(input))
							updateItem.CommunityContribution = int.Parse(input);

						Console.Write($"IsTopRanked ({updateItem.IsTopRanked}): ");
						input = Console.ReadLine();
						if (!string.IsNullOrWhiteSpace(input))
							updateItem.IsTopRanked = bool.Parse(input);

						updateItem.LastUpdate = DateTime.Now;

						Console.WriteLine("Sending update:");
						Console.WriteLine(JsonSerializer.Serialize(updateItem, new JsonSerializerOptions { WriteIndented = true }));

						var updateResult = await client.UpdateAsync(updateItem);
						Console.WriteLine(updateResult > 0 ? "Update successed!" : "Update successed!!");
						break;

					case "5":
						Console.Write("Enter ID to delete: ");
						int deleteId = int.Parse(Console.ReadLine());
						var deleteResult = await client.DeleteAsync(deleteId);
						Console.WriteLine($"Delete successed");
						break;

					case "0":
						running = false;
						break;

					default:
						Console.WriteLine("Invalid choice");
						break;
				}
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Error: {ex.Message}");
				if (ex.InnerException != null)
					Console.WriteLine("Inner: " + ex.InnerException.Message);
				Console.ResetColor();
			}

			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
		}

		if (client is IClientChannel ch && ch.State == CommunicationState.Opened)
			ch.Close();
	}
}
