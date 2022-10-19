using Services;

namespace PetroineosService.Services;

public interface IPowerServiceDataProvider
{
    Task<IEnumerable<PowerTrade>> GetData(DateTime requestDate);
}