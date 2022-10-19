using Services;

namespace PetroineosService.Services;

public class PowerServiceDataProvider : IPowerServiceDataProvider
{
    private PowerService _powerService;

    public PowerServiceDataProvider()
    {
        _powerService = new PowerService();
    }

    public async Task<IEnumerable<PowerTrade>> GetData(DateTime requestDate)
    {
        return await _powerService.GetTradesAsync(requestDate);
    }
}