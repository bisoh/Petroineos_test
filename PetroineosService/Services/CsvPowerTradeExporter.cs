using System.Text;
using Services;

namespace PetroineosService.Services;

public class CsvPowerTradeExporter : IPowerTradeExporter
{
    public string Export(PowerTrade content)
    {
        StringBuilder sb = new StringBuilder("LocalTime,Volume");
        sb.AppendLine();
        foreach (var period in content.Periods.OrderBy(c => c.Period))
        {
            sb.AppendLine($"{TimeSpan.FromHours(22 + period.Period).Hours.ToString("00")}:00,{period.Volume}");
        }

        return sb.ToString().Trim();
    }
}