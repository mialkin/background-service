using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundService.Api;

public class SampleHostedLifecycleService(ILogger<SampleHostedLifecycleService> logger) : IHostedLifecycleService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        logger.LogInformation(nameof(StartAsync));
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        logger.LogInformation(nameof(StopAsync));
    }

    public async Task StartedAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        logger.LogInformation(nameof(StartedAsync));
    }

    public async Task StartingAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        logger.LogInformation(nameof(StartingAsync));
    }

    public async Task StoppedAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        logger.LogInformation(nameof(StoppedAsync));
    }

    public async Task StoppingAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        logger.LogInformation(nameof(StoppingAsync));
    }
}