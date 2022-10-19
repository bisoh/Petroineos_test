using Services;

namespace PetroineosService.Services;

public interface IPowerDataProvider
{
    Task<IEnumerable<PowerTrade>> GetData(DateTime requestDate);
}