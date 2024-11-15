using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinConversion
{
    public class Conversion
    {
        public decimal Amount { get; private set; }
        public string FromCurrency { get; private set; }
        public string ToCurrency { get; private set; }
        public decimal ConvertedAmount { get; private set; }
        public DateTime Date { get; private set; }

        public Conversion(decimal amount, string fromCurrency, string toCurrency, decimal convertedAmount)
        {
            Amount = amount;
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            ConvertedAmount = convertedAmount;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Date}: {Amount} {FromCurrency} = {ConvertedAmount} {ToCurrency}";
        }
    }
}
