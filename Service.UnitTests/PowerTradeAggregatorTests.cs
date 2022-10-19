using PetroineosService.Services;
using Services;

namespace Service.UnitTests;

public class PowerTradeAggregatorTests
{
    private PowerTradeAggregator _sut;
    private DateTime _date = DateTime.Today;

    [SetUp]
    public void Setup()
    {
        _sut = new PowerTradeAggregator();
    }

    [Test]
    public void Aggregates2PowerTradesCorrectly()
    {
        var input = PowerTrade.Create(DateTime.Now, 24);
        TestHelper.ManipulateInput(input);
        var input2 = PowerTrade.Create(DateTime.Now, 24);
        TestHelper.ManipulateInput(input2);

        List<PowerTrade> listOfInput = new List<PowerTrade>()
        {
            input, input2
        };

        var result = _sut.AggregatePowerTrades(listOfInput);

        Assert.AreEqual(24, result.Periods.Length);

        for (int i = 0; i < 12; i++)
        {
            Assert.AreEqual(200, result.Periods[i].Volume);

        }
        for (int i = 12; i < input.Periods.Length; i++)
        {
            Assert.AreEqual(100, result.Periods[i].Volume);
        }
    }

    [Test]
    public void Aggregates3PowerTradesCorrectly()
    {
        var input = PowerTrade.Create(DateTime.Now, 24);
        TestHelper.ManipulateInput(input);
        var input2 = PowerTrade.Create(DateTime.Now, 24);
        TestHelper.ManipulateInput(input2);
        var input3 = PowerTrade.Create(DateTime.Now, 24);
        TestHelper.ManipulateInput(input3);

        List<PowerTrade> listOfInput = new List<PowerTrade>()
        {
            input, input2, input3
        };

        var result = _sut.AggregatePowerTrades(listOfInput);

        Assert.AreEqual(24, result.Periods.Length);

        for (int i = 0; i < 12; i++)
        {
            Assert.AreEqual(300, result.Periods[i].Volume);

        }
        for (int i = 12; i < input.Periods.Length; i++)
        {
            Assert.AreEqual(150, result.Periods[i].Volume);
        }
    }
}