using Services;

namespace PetroineosService.Services;

public interface IPowerTradeFormatter
{
    string Export(PowerTrade content);
}