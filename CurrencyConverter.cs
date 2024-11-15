using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinConversion
{
    public class CurrencyConverter
    {
        private readonly CurrencyService currencyService;

        public CurrencyConverter(CurrencyService service)
        {
            currencyService = service;
        }

        public decimal Convert(decimal amount, string fromCurrency, string toCurrency)
        {
            decimal fromRate = currencyService.GetExchangeRate(fromCurrency);
            decimal toRate = currencyService.GetExchangeRate(toCurrency);

            return amount / fromRate * toRate;
        }
    }
}
