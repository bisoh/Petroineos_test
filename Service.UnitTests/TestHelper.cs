using Services;

namespace Service.UnitTests;

public class TestHelper
{
    /// <summary>
    /// PowerTrade properties have internal setter. This is making it hard to test the the Aggregator because
    /// I don't know what numbers will be generated everytime, so I can't have an expected result.
    /// This function is to update PowerTrade volumes to some static values so we can test our Aggregation logic.
    /// </summary>
    public static void ManipulateInput(PowerTrade input)
    {
        for (int i = 0; i < 12; i++)
        {
            input.Periods[i].Period = i; // setting this because the GetTradesAsync returns Periods starting from 0. but the Create function starts at 1
            input.Periods[i].Volume = 100;
        }
        for (int i = 12; i < input.Periods.Length; i++)
        {
            input.Periods[i].Period = i; // setting this because the GetTradesAsync returns Periods starting from 0. but the Create function starts at 1
            input.Periods[i].Volume = 50;
        }
    }
}