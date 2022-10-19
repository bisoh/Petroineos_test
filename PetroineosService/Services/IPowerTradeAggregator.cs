using Services;

namespace PetroineosService.Services;

public interface IPowerTradeAggregator
{
    PowerTrade AggregatePowerTrades (List<PowerTrade> powerTrades);
}