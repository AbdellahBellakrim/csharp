using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();   // 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

// this code is used to add the customized ProblemDetails middleware to the pipeline
// builder.Services.AddProblemDetails(
//     options => options.CustomizeProblemDetails = ctx => { ctx.ProblemDetails.Extensions.Add("addionalInfo", "Some additional information"); ctx.ProblemDetails.Extensions.Add("server", Environment.MachineName); }
// );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
