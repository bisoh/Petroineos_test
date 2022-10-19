# Readme

## Assumptions
- All PowerTrade Positions contain 24 periods. The Create function allows for a number to be passed but for the purpose of the test I am assuming its 24 only. 
- csv Timeframes are at the hour.
- When the services runs to do the trading/aggregation, the identifier for the run is `DateTime.Now`

---
## Improvements

- replace the DateTime.Now with an abstraction so you can test it the correct date is being passed in the manager
- The formatter and exporter need to be 'tied up' somehow so that you dont format the data as json and export it to CSV. (Not coupling) 
- passing in `IConfiguration` for simplicity given its only one config. If we had many, I would group them in objects with similar symantics 