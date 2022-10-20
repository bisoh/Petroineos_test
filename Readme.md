# Readme

## How to run

Run the `PetroineosService` project and it should generate a file every 20 seconds. Interval is short so its easier to test.

Files are generated in `PetroineosTest\PetroineosService\test`

Change the config called `exportFileLocation` to change the location. Empty value will drop it in the "PetroineosService" folder.

_**I have changed the file name to include seconds because it will generate multiple files/minute**_

---

## Notes

I started this focusing on getting the logic to work without caring much about performance. My next step was to improve the aggregation logic

---

## Assumptions

-   All PowerTrade Positions contain 24 periods. The Create function allows for a number to be passed but for the purpose of the test I am assuming its 24 only.
-   csv Timeframes are at the hour.
-   When the services runs to do the trading/aggregation, the identifier for the run is time at which it starts.

---

## Improvements

-   Replace the `DateTime.Now` with an abstraction so you can test the correct date is being passed in the manager
-   When the formatter and exporter have move implementations, they need to be 'tied up' somehow (without coupling) so that you dont format the data as json and export it to CSV for example.
-   Passing in `IConfiguration` for simplicity given its only 2 configs. If we had many, I would group them in objects with similar symantics
-   Add more tests to the exporter to test exporting to the path functionality
-   More exception handling
-   The aggregator now works ok. However, I expect with large quantities of data it may not be fast enough. In that case I think maybe using map/reduce Aggregator would improve performance.