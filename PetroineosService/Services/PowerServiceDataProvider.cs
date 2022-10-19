using Services;

namespace PetroineosService.Services;

public class PowerDataProvider : IPowerDataProvider
{
    private PowerService _powerService;

    public PowerDataProvider()
    {
        _powerService = new PowerService();
    }

    public async Task<IEnumerable<PowerTrade>> GetData(DateTime requestDate)
    {
        return await _powerService.GetTradesAsync(requestDate);
    }
}