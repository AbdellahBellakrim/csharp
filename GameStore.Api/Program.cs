using GameStore.Api.data;
using GameStore.Api.EndPoints;
using GameStore.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();

// ConnectionStrings:GameStoreContext = Server=localhost;Database=GameStore;User Id=sa;Password=Your_password123;TrustServerCertificate=True
var connString = builder.Configuration.GetConnectionString("GameStoreContext");
builder.Services.AddSqlServer<GameStoreContext>(connString);


var app = builder.Build();
app.MapGamesEndpoints();
app.Run();
