using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundService.Api;

public class SampleHostedService(ILogger<SampleHostedService> logger) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation(nameof(StartAsync));
        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        logger.LogInformation(nameof(StartAsync) + " end");
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation(nameof(StopAsync));
        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        logger.LogInformation(nameof(StopAsync) + " end");
    }
}