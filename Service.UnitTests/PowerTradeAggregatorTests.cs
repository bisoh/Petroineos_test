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
        ManipulateInput(input);
        var input2 = PowerTrade.Create(DateTime.Now, 24);
        ManipulateInput(input2);

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

    /// <summary>
    /// PowerTrade properties have internal setter. This is making it hard to test the the aggregation because
    /// I don't know what numbers will be generated everytime, so I can't have an expected result.
    /// This function is to update PowerTrade volumes to some static values so we can test our Aggregation logic.
    /// </summary>
    /// <param name="input"></param>
    private void ManipulateInput(PowerTrade input)
    {
        for (int i = 0; i < 12; i++)
        {
            input.Periods[i].Volume = 100;
        }
        for (int i = 12; i < input.Periods.Length; i++)
        {
            input.Periods[i].Volume = 50;
        }
    }


}