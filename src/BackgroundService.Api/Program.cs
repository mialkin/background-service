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

/*
builder.Services.Configure<HostOptions>(x =>
    {
        x.ServicesStartConcurrently = true;
        x.ServicesStopConcurrently = true;
    }
);

builder.Services.AddHostedService<SampleHostedService>();
builder.Services.AddHostedService<SampleHostedLifecycleService>();
*/

var application = builder.Build();

application.MapGet("/", () => "Hello World!");

application.Run();