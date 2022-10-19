using Services;

namespace PetroineosService.Services;

public interface IPowerTradeAggregator
{
    PowerTrade AggregatePowerTrades (List<PowerTrade> powerTrades);
}

public class PowerTradeAggregator : IPowerTradeAggregator
{
    public PowerTrade AggregatePowerTrades(List<PowerTrade> powerTrades)
    {
        var result = PowerTrade.Create(powerTrades[0].Date, 24);
        for (int i = 0; i <= 23; i++)
        {
            result.Periods[i].Period = i;
            result.Periods[i].Volume = 0;
            foreach (var powerTrade in powerTrades)
            {
                result.Periods[i].Volume += powerTrade.Periods[i].Volume;
            }
        }

        return result;
    }
}