# Readme

## Assumptions
- All PowerTrade Positions contain 24 periods. The Create function allows for a number to be passed but for the purpose of the test I am assuming its 24 only. 
- csv Timeframes are at the hour.


---
## Improvements

- replace the DateTime.Now with an abstraction so you can test it the correct date is being passed in the manager