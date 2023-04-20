using BackgroundService.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
    configuration.WriteTo.Console();
});

builder.Services.AddHostedService<SampleBackgroundService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();