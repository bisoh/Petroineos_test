using PetroineosService;
using PetroineosService.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IPowerTradeAggregator, PowerTradeAggregator>();
        services.AddSingleton<IPowerTradeFormatter, CsvPowerTradeFormatter>();
        services.AddSingleton<IPowerDataProvider, PowerDataProvider>();
        services.AddSingleton<PowerTradingManager>();
    })
    .Build();

await host.RunAsync();