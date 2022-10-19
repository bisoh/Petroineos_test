using PetroineosService.Services;
using Services;

namespace PetroineosService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly PowerTradingManager _manager;

    public Worker(ILogger<Worker> logger, PowerTradingManager manager)
    {
        _logger = logger;
        _manager = manager;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(3000, stoppingToken);

            await _manager.Trade();



        }
    }
}