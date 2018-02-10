# coinmarketcap
An example of NET core wrapper around the https://coinmarketcap.com API.
With configurable timing, the data are downloaded in csv files and refreshed on CoinMarketData.xlsm template. 


## Requirements:

- NET Core SDK


## API's supported:

- Ticker (Specific Currency)


## Steps:

- Edit parameters on appsettings.json config file. The times are in milliseconds
- Edit refreshing time on CoinMarketData.xlsm template (sheet: Configuration)
- Locate project folder and execute from commandline: dotnet coinmarketcap.dll
- Configure on excel template new queries based on csv generated

