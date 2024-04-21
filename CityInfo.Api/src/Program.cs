using AutoMapper;
using CityInfo.Api.src.dataStores;
using CityInfo.Api.src.dbContexts;
using CityInfo.Api.src.services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day).CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
builder.Services.AddDbContext<CityInfoContext>(dbContectxOptions => dbContectxOptions.UseSqlServer(builder.Configuration.GetConnectionString("CityInfoConnectionString")));
builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// compile directive to use the LocalMailService in development and the CloudMailService in production
#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else
builder.Services.AddTransient<IMailService, CloudMailService>();
#endif

builder.Services.AddSingleton<CitiesDataStore>();

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
