using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BackgroundService.Api;

public class SampleBackgroundService(ILogger<SampleBackgroundService> logger)
    : Microsoft.Extensions.Hosting.BackgroundService
{
    private const int Seconds = 5;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var stopwatch = new Stopwatch();

            try
            {
                logger.LogInformation("Start running task");
                stopwatch.Start();

                await Task.Delay(TimeSpan.FromSeconds(Random.Shared.Next(10)), stoppingToken);

                logger.LogInformation("End running task");
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Error running task");
            }
            finally
            {
                stopwatch.Stop();
                var timeSpan = stopwatch.Elapsed;
                var elapsedTime = $"{timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";

                logger.LogInformation("End background service run cycle. Elapsed time: {ElapsedTime}", elapsedTime);
            }

            logger.LogInformation("Sleeping {Seconds} seconds", Seconds);
            await Task.Delay(TimeSpan.FromSeconds(Seconds), stoppingToken);
        }
    }
}