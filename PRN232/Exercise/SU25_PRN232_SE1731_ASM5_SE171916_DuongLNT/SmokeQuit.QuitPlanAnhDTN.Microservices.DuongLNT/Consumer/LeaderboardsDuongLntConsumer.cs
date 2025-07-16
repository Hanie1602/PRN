using MassTransit;
using SmokeQuit.BussinessObject.Shared.Models.DuongLNT.Models;
using SmokeQuit.Common.Shared.DuongLNT;

namespace SmokeQuit.QuitPlanAnhDTN.Microservices.DuongLNT.Consumer
{
	public class LeaderboardsDuongLntConsumer : IConsumer<LeaderboardsDuongLnt>
	{
		private readonly ILogger<LeaderboardsDuongLntConsumer> _logger;

		public LeaderboardsDuongLntConsumer(ILogger<LeaderboardsDuongLntConsumer> logger)
		{
			_logger = logger;
		}

		public async Task Consume(ConsumeContext<LeaderboardsDuongLnt> context)
		{
			var data = context.Message;

			if (data != null)
			{
				string messageLog = string.Format("[{0}] RECEIVE data from RabbitMQ.orderQueue: {1}", DateTime.Now.ToString(), Utilities.ConvertObjectToJSONString(data));

				Utilities.WriteLoggerFile(messageLog);

				_logger.LogInformation(messageLog);

				// Implement the logic to handle the booking here
				_logger.LogInformation("The leaderboard have been noted: {Note}", context.Message.Note);
				// Additional processing logic can be added here

			}
		}

	}
}
