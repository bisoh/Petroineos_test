namespace PetroineosService.Services;

public class CsvExporter : IExporter
{
    private const string Extension = ".csv";
    private ILogger<CsvExporter> _logger;
    public CsvExporter(ILogger<CsvExporter> logger)
    {
        _logger = logger;
    }
    public async Task Export(string fileName, string content)
    {
        _logger.LogInformation($"Exporting file {fileName}.{Extension}");
        await File.WriteAllTextAsync($"{fileName}.{Extension}", content);
    }
}