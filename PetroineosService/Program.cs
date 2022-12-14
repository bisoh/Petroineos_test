using PetroineosService;
using PetroineosService.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<TimedHostedService>();
        services.AddSingleton<IPowerTradeAggregator, PowerTradeAggregator>();
        services.AddSingleton<IPowerTradeFormatter, CsvPowerTradeFormatter>();
        services.AddSingleton<IPowerDataProvider, PowerDataProvider>();
        services.AddSingleton<IExporter, CsvExporter>();
        services.AddSingleton<PowerTradingManager>();
    })
    .Build();


await host.RunAsync();