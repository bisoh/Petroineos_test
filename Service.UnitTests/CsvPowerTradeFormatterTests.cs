using PetroineosService.Services;
using Services;

namespace Service.UnitTests;

[TestFixture]
public class CsvPowerTradeFormatterTests
{
    private CsvPowerTradeFormatter _sut;

    [SetUp]
    public void SetUp()
    {
        _sut = new CsvPowerTradeFormatter();
    }

    [Test]
    public void Format_ExportsCsvCorrectly()
    {
        var input = PowerTrade.Create(DateTime.Now, 24);
        TestHelper.ManipulateInput(input);

        var result = _sut.Format(input);
        var expected = "LocalTime,Volume\r\n23:00,100\r\n00:00,100\r\n01:00,100\r\n02:00,100\r\n03:00,100\r\n04:00,100\r\n05:00,100\r\n06:00,100\r\n07:00,100\r\n08:00,100\r\n09:00,100\r\n10:00,100\r\n11:00,50\r\n12:00,50\r\n13:00,50\r\n14:00,50\r\n15:00,50\r\n16:00,50\r\n17:00,50\r\n18:00,50\r\n19:00,50\r\n20:00,50\r\n21:00,50\r\n22:00,50";

        Assert.AreEqual(expected, result);

    }
}