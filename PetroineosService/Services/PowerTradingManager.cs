namespace PetroineosService.Services;

public class PowerTradingManager
{
    private readonly IPowerDataProvider _powerDataProvider;
    private readonly IPowerTradeAggregator _aggregator;
    private readonly IPowerTradeFormatter _formatter;
    private readonly IExporter _exporter;

    public PowerTradingManager(IPowerDataProvider powerDataProvider, IPowerTradeAggregator aggregator,
        IPowerTradeFormatter formatter, IExporter exporter)
    {
        _powerDataProvider = powerDataProvider;
        _aggregator = aggregator;
        _formatter = formatter;
        _exporter = exporter;
    }

    public async Task Trade()
    {
        var data = await _powerDataProvider.GetData(DateTime.Now);

        var aggregatedData = _aggregator.AggregatePowerTrades(data.ToList());

        string fileName = $"PowerPosition_{DateTime.Now.ToString("yyyyMMdd_HHmm")}";

        var exportedData = _formatter.Format(aggregatedData);

        await _exporter.Export(fileName, exportedData);
    }
}