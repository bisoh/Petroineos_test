namespace PetroineosService.Services;

public class CsvExporter : IExporter
{
    private const string Extension = ".csv";
    
    public async Task Export(string fileName, string content)
    {
        await File.WriteAllTextAsync($"{fileName}.{Extension}", content);
    }
}