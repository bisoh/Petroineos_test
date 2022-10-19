namespace PetroineosService.Services;

public class PowerTradingManager
{
    private readonly IPowerServiceDataProvider _powerServiceDataProvider;
    private readonly IPowerTradeAggregator _aggregator;
    private readonly IPowerTradeFormatter _formatter;

    public PowerTradingManager(IPowerServiceDataProvider powerServiceDataProvider, IPowerTradeAggregator aggregator,
        IPowerTradeFormatter formatter)
    {
        _powerServiceDataProvider = powerServiceDataProvider;
        _aggregator = aggregator;
        _formatter = formatter;
    }

    public async Task Trade()
    {
        var data = await _powerServiceDataProvider.GetData(DateTime.Now);

        var aggregatedData = _aggregator.AggregatePowerTrades(data.ToList());
        string fileName = $"PowerPosition_{DateTime.Now.ToString("yyyyMMdd_HHmm")}.csv";
        var exportedData = _formatter.Export(aggregatedData);
        await File.WriteAllTextAsync(fileName, exportedData);
    }
}