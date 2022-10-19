# Readme

## Assumptions
- All PowerTrade Positions contain 24 periods. The Create function allows for a number to be passed but for the purpose of the test I am assuming its 24 only. 
- csv Timeframes are at the hour.
- When the services runs to do the trading/aggregation, the identifier for the run is `DateTime.Now`

---

## How to run

Run the service and it should generate a file every 2 seconds. Interval is short so its easier to test. 

_**I have changed the file name to include seconds because it will generate multiple files/minute**_ 

Change the config called `exportFileLocation` to change the location. Empty value will drop it in the "PetroineosService" folder.

---
## Improvements

- replace the DateTime.Now with an abstraction so you can test it the correct date is being passed in the manager
- The formatter and exporter need to be 'tied up' somehow so that you dont format the data as json and export it to CSV. (Not coupling) 
- passing in `IConfiguration` for simplicity given its only one config. If we had many, I would group them in objects with similar symantics 
- add more tests to the exporter to test exporting to the path functionality