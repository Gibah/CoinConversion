using CoinConversion;

var currencyService = new CurrencyService();
var converter = new CurrencyConverter(currencyService);
var conversionHistory = new List<Conversion>();

while (true)
{
    Console.WriteLine("\nChoose an option:");
    Console.WriteLine("1. Convert Coin");
    Console.WriteLine("2. View conversion history");
    Console.WriteLine("3. Exit");
    Console.WriteLine("Options:");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter a value to convert: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.Write("Enter the origin coin (Ex: USD): ");
                var fromCurrency = Console.ReadLine().ToUpper();

                Console.Write("Enter the target coin (Ex: EUR): ");
                var toCurrency = Console.ReadLine().ToUpper();

                try
                {
                    var convertedAmount = converter.Convert(amount, fromCurrency, toCurrency);
                    var conversion = new Conversion(amount, fromCurrency, toCurrency, convertedAmount);
                    conversionHistory.Add(conversion);

                    Console.WriteLine($"Result: {amount} {fromCurrency} = {convertedAmount} {toCurrency}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid Value.");
            }
            break;

        case "2":
            Console.WriteLine("Conversions historic: ");
            if (conversionHistory.Count == 0)
            {
                Console.WriteLine("None Conversion created.");
            }
            else
            {
                foreach (var conversion in conversionHistory)
                {
                    Console.WriteLine(conversion);
                }
            }
            break;

        case "3":
            Console.WriteLine("Finishing program...");
            return;

        default:
            Console.WriteLine("Invalid Option. Please, choose an option between 1 to 3.");
            break;
    }
}
