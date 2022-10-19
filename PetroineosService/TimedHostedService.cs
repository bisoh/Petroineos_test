using PetroineosService.Services;

namespace PetroineosService;

public class TimedHostedService : IHostedService, IDisposable
{
    private readonly ILogger<TimedHostedService> _logger;
    private readonly PowerTradingManager _manager;
    private readonly IConfiguration _config;
    private Timer? _timer = null;

    public TimedHostedService(ILogger<TimedHostedService> logger, PowerTradingManager manager, IConfiguration config)
    {
        _logger = logger;
        _manager = manager;
        _config = config;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service running.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(Convert.ToInt32(_config["runTradeEveryXSeconds"])));

        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        _logger.LogInformation("Running tradder");
        _manager.Trade().ConfigureAwait(false).GetAwaiter().GetResult();

    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}