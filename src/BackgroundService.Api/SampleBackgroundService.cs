using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BackgroundService.Api;

public class SampleBackgroundService(ILogger<SampleBackgroundService> logger)
    : Microsoft.Extensions.Hosting.BackgroundService
{
    private const int Minutes = 1;

    private static readonly PeriodicTimer Timer = new(TimeSpan.FromMinutes(Minutes));

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Timed hosted service is starting");

        using PeriodicTimer timer = new(TimeSpan.FromMinutes(1));

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                logger.LogInformation("Doing some business logic at: {time}", DateTimeOffset.Now);
                await Task.Delay(TimeSpan.FromSeconds(Random.Shared.Next(10, 50)), stoppingToken);
                logger.LogInformation("Finished doing some business logic at: {time}", DateTimeOffset.Now);
            }
            catch (OperationCanceledException)
            {
                logger.LogInformation("Timed hosted service is stopping");
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Error occurred");
            }

            await timer.WaitForNextTickAsync(stoppingToken);
        }
    }
}