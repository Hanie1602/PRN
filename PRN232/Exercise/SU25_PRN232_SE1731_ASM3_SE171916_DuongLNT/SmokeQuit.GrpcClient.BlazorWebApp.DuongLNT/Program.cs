using SmokeQuit.GrpcClient.BlazorWebApp.DuongLNT.Components;
using SmokeQuit.GrpcServices.DuongLNT.Protos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpcClient<LeaderboardsDuongLntGRPC.LeaderboardsDuongLntGRPCClient>(o =>
{
	o.Address = new Uri("https://localhost:7262");
});

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
