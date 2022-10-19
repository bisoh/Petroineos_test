using Moq;
using PetroineosService.Services;
using Services;

namespace Service.UnitTests;

[TestFixture]
public class PowerTradeManagerTests
{
    private PowerTradingManager _sut;

    private Mock<IPowerDataProvider> _powerDataProviderMock;
    private Mock<IPowerTradeAggregator> _aggregatorMock;
    private Mock<IPowerTradeFormatter> _formatterMock;
    private Mock<IExporter> _exporterMock;

    [SetUp]
    public void SetUp()
    {
        _powerDataProviderMock = new Mock<IPowerDataProvider>();
        _aggregatorMock = new Mock<IPowerTradeAggregator>();
        _formatterMock = new Mock<IPowerTradeFormatter>();
        _exporterMock = new Mock<IExporter>();

        var powerTradeData = PowerTrade.Create(DateTime.Now, 2);

        TestHelper.ManipulateInput(powerTradeData);

        _powerDataProviderMock.Setup(c => c.GetData(It.IsAny<DateTime>()))
            .ReturnsAsync(new List<PowerTrade>()
            {
                powerTradeData
            });

        _aggregatorMock.Setup(c => c.AggregatePowerTrades(It.IsAny<List<PowerTrade>>())).Returns(powerTradeData);


        _formatterMock.Setup(c => c.Format(It.IsAny<PowerTrade>())).Returns("anything");

        _sut = new PowerTradingManager(_powerDataProviderMock.Object,
            _aggregatorMock.Object,
            _formatterMock.Object,
            _exporterMock.Object);
    }

    [Test]
    public void Trade_CallsDataProvider()
    {
        _sut.Trade();
        _powerDataProviderMock.Verify(c => c.GetData(It.IsAny<DateTime>()));
    }

    [Test]
    public async Task Trade_CallsAggregatorWithCorrectData()
    {
        await _sut.Trade();

        _aggregatorMock.Verify(c => c.AggregatePowerTrades(It.Is<List<PowerTrade>>(
            a =>
                a.First().Periods.First().Volume == 100
                && a.First().Periods.Last().Volume == 50)));
    }

    [Test]
    public async Task Trade_CallsFormatterWithCorrectData()
    {
        await _sut.Trade();

        _formatterMock.Verify(c => c.Format(It.Is<PowerTrade>(
            a =>
                a.Periods.First().Volume == 100
                && a.Periods.Last().Volume == 50)));
    }

    [Test]
    public async Task Trade_CallsExporterWithCorrectData()
    {
        await _sut.Trade();

        _exporterMock.Verify(c => c.Export(It.IsAny<string>(), "anything"));
    }
}