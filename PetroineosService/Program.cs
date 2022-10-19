using PetroineosService;
using PetroineosService.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IPowerTradeAggregator, PowerTradeAggregator>();
        services.AddSingleton<IPowerTradeExporter, CsvPowerTradeExporter>();
        services.AddSingleton<IPowerServiceDataProvider, PowerServiceDataProvider>();
        services.AddSingleton<PowerTradingManager>();
    })
    .Build();

await host.RunAsync();