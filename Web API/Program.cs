using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using Serilog.AspNetCore;
using Web_API;
using Web_API.Data;
using Web_API.Models;
try
{
    var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    //.Enrich.FromLogContext()
    .CreateLogger();
   Log.Information("Starting Web API");

    // Add services to the container.
    builder.Services.AddSingleton<IDatabaseClient<User>, DatabaseClient<User>>();
    builder.Services.AddSingleton<UserServices>();
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Host.UseSerilog(Log.Logger);
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
    }

    // Global Exception handler
    app.UseExceptionHandler(error => {
        error.Run(async context =>
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null)
            {
                Log.Error($"Something went wrong in the {contextFeature.Error}");
                await context.Response.WriteAsync(new Error
                {
                    StatusCode = context.Response.StatusCode,
                    Message = contextFeature.Error.Message,
                }.ToString());
            }
        });
    });
    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Error(ex, "Error");
}
