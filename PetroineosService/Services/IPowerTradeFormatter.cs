using Services;

namespace PetroineosService.Services;

public interface IPowerTradeFormatter
{
    string Format(PowerTrade content);
}