using System.Text;

namespace PetroineosService.Services;

public class CsvExporter : IExporter
{
    private const string Extension = ".csv";
    private ILogger<CsvExporter> _logger;
    private readonly IConfiguration _config;
    private readonly string _fileLocationPrefix;

    public CsvExporter(ILogger<CsvExporter> logger, IConfiguration config)
    {
        _logger = logger;
        _fileLocationPrefix = config["exportFileLocation"];
    }
    public async Task Export(string fileName, string content)
    {
        if (string.IsNullOrWhiteSpace(_fileLocationPrefix))
        {
            _logger.LogInformation($"Exporting CSV file to {fileName}{Extension}");

            await File.WriteAllTextAsync($"{fileName}{Extension}", content);
        }
        else
        {
            var fileLocation = $"{_fileLocationPrefix}\\{fileName}{Extension}";
            _logger.LogInformation($"Exporting CSV file to {fileLocation}");

            if (Directory.Exists(_fileLocationPrefix) == false)
            {
                Directory.CreateDirectory(_fileLocationPrefix);
            }

            await File.WriteAllTextAsync($"{fileLocation}", content);
        }
    }
}