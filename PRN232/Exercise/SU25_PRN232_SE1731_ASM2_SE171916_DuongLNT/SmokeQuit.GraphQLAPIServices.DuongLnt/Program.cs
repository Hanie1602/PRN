using SmokeQuit.GraphQLAPIServices.DuongLnt.GraphQLs;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGraphQLServer()
	.AddQueryType<LeaderboardsQueries>()
	.AddMutationType<Mutations>()
	.BindRuntimeType<DateTime, DateTimeType>();

//Cấu hình CORS cho phép Blazor WASM truy cập
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowBlazorWASM",
		policy =>
		{
			policy.WithOrigins("https://localhost:7276")
				  .AllowAnyHeader()
				  .AllowAnyMethod();
		});
});

builder.Services.AddScoped<IServiceProviders, ServiceProviders>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
	options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowBlazorWASM"); //Add CORS policy

app.UseAuthorization();

app.MapControllers();

app.UseRouting();
app.UseRouting().UseEndpoints(endpoints => { endpoints.MapGraphQL(); });

app.Run();
