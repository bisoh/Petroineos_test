using Services;

namespace PetroineosService.Services;

public interface IPowerTradeExporter
{
    string Export(PowerTrade content);
}