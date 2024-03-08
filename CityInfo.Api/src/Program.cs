using Microsoft.AspNetCore.StaticFiles;
using Serilog;

Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day).CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

// use serilog as the default logger
builder.Host.UseSerilog();

// this code is used to add the customized ProblemDetails middleware to the pipeline
// builder.Services.AddProblemDetails(
//     options => options.CustomizeProblemDetails = ctx => { ctx.ProblemDetails.Extensions.Add("addionalInfo", "Some additional information"); ctx.ProblemDetails.Extensions.Add("server", Environment.MachineName); }
// );

// this code is used to add ProblemDetails middleware to the pipeline
builder.Services.AddProblemDetails();


var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
