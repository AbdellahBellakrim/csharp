using GameStore.Api.data;
using GameStore.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories(builder.Configuration);
var app = builder.Build();
await app.Services.InitializeDbAsync();
app.MapGamesEndpoints();
app.Run();
