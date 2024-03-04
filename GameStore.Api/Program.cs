using GameStore.Api.data;
using GameStore.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories(builder.Configuration);
var app = builder.Build();
app.Services.InitializeDb();
app.MapGamesEndpoints();
app.Run();
 