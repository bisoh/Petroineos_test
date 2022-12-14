using System.Text;
using Services;

namespace PetroineosService.Services;

public class CsvPowerTradeFormatter : IPowerTradeFormatter
{
    private Dictionary<int, string> hourMap = new()
    {
        { 0	, "23:00" },
        { 1	, "00:00" },
        { 2	, "01:00" },
        { 3	, "02:00" },
        { 4	, "03:00" },
        { 5	, "04:00" },
        { 6	, "05:00" },
        { 7	, "06:00" },
        { 8	, "07:00" },
        { 9		, "08:00" },
        { 10	, "09:00" },
        { 11	, "10:00" },
        { 12	, "11:00" },
        { 13	, "12:00" },
        { 14	, "13:00" },
        { 15	, "14:00" },
        { 16	, "15:00" },
        { 17	, "16:00" },
        { 18	, "17:00" },
        { 19	, "18:00" },
        { 20	, "19:00" },
        { 21	, "20:00" },
        { 22	, "21:00" },
        { 23	, "22:00" }
    };

    public string Format(PowerTrade content)
    {
        StringBuilder sb = new StringBuilder("LocalTime,Volume");
        sb.AppendLine();
        foreach (var period in content.Periods.OrderBy(c => c.Period))
        {
            sb.AppendLine($"{hourMap[period.Period]},{period.Volume}");
        }

        return sb.ToString().Trim();
    }
}