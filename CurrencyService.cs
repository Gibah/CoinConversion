using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CoinConversion
{
    public class CurrencyService
    {
        private readonly HttpClient httpClient;
        private Dictionary<string, decimal> exchangeRates;
        private const string ApiUrl = "https://api.exchangeratesapi.io/latest?base=USD&access_key=673181b0b7aaf9d44c291fbac63ac4ea";

        public CurrencyService()
        {
            httpClient = new HttpClient();
            exchangeRates = new Dictionary<string, decimal>();
            /*{
                { "USD", 1.00m },
                { "EUR", 0.85m },
                { "GBP", 0.75m },
                { "BRL", 5.20m },
                { "JPY", 110.15m }
            };
            */
        }

        public async Task<bool> UpdateExchangeRatesAsync()
        {
            try
            {
                // Request to the API and Get taxes exchange
                var response = await httpClient.GetFromJsonAsync<ExchangeRateResponse>(ApiUrl);

                if (response != null && response.Rates != null)
                {
                    exchangeRates = response.Rates;
                    Console.WriteLine("Exchange Taxes updated successfully.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error to get exchange taxes.");
                    return false;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error to update exchange taxes: {ex.Message}.");
                return false;
            }
        }
        
        public decimal GetExchangeRate(string currencyCode)
        {
            if(exchangeRates.ContainsKey(currencyCode)) 
            {
                return exchangeRates[currencyCode];
            }
            else
            {
                throw new ArgumentException("Coin code not supported");
            }
        }
    }
}
