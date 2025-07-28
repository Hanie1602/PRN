using MassTransit;
using SmokeQuit.QuitPlanAnhDTN.Microservices.DuongLNT.Consumer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.ConfigureLogging(logging =>
{
	logging.ClearProviders();
	logging.AddConsole();
});

builder.Services.AddMassTransit(x =>
{

	x.AddConsumer<LeaderboardsDuongLntConsumer>();
	x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
	{
		//cfg.UseHealthCheck(provider);
		//cfg.Host(new Uri("rabbitmq://localhost:xxxx"), h =>
		cfg.Host(new Uri("rabbitmq://localhost"), h =>
		{
			h.Username("guest");
			h.Password("guest");
		});

		cfg.ReceiveEndpoint("orderQueue", ep =>
		{
			ep.PrefetchCount = 16;
			ep.UseMessageRetry(r => r.Interval(2, 100));

			ep.ConfigureConsumer<LeaderboardsDuongLntConsumer>(provider);
		});
	}));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
