namespace PetroineosService.Services;

public class PowerTradingManager
{
    private readonly IPowerDataProvider _powerDataProvider;
    private readonly IPowerTradeAggregator _aggregator;
    private readonly IPowerTradeFormatter _formatter;
    private readonly IExporter _exporter;
    private ILogger<PowerTradingManager> _logger;

    public PowerTradingManager(IPowerDataProvider powerDataProvider, IPowerTradeAggregator aggregator,
        IPowerTradeFormatter formatter, IExporter exporter, ILogger<PowerTradingManager> logger)
    {
        _powerDataProvider = powerDataProvider;
        _aggregator = aggregator;
        _formatter = formatter;
        _exporter = exporter;
        _logger = logger;
    }

    public async Task Trade()
    {
        var startTime = DateTime.Now;
        try
        {
            _logger.LogInformation($"Getting data at {startTime}");
            var data = await _powerDataProvider.GetData(startTime);

            _logger.LogInformation($"Aggregating {data.Count()} PowerTrader");
            var aggregatedData = _aggregator.AggregatePowerTrades(data.ToList());

            string fileName = $"PowerPosition_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}";

            _logger.LogInformation($"Formatting data that started at {startTime}");

            var exportedData = _formatter.Format(aggregatedData);

            await _exporter.Export(fileName, exportedData);

            _logger.LogInformation($"Trading successfully completed for data @ {startTime}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,$"An exception has occured for data processed at {startTime}");
            throw;
        }

    }
}