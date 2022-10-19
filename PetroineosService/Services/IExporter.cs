namespace PetroineosService.Services;

public interface IExporter
{
    Task Export(string fileName, string content);
}