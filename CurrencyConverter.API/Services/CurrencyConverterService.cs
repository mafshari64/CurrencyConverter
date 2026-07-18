using CurrencyConverter.API.Converters;

namespace CurrencyConverter.API.Services;

public class CurrencyConverterService
{
    private readonly EnglishConverter _englishConverter;
    private readonly GermanConverter _germanConverter;

    public CurrencyConverterService(
        EnglishConverter englishConverter,
        GermanConverter germanConverter)
    {
        _englishConverter = englishConverter;
        _germanConverter = germanConverter;
    }

public string Convert(string amount, string language, string currency)
{
    if (string.IsNullOrWhiteSpace(amount))
    {
        return "Please enter an amount.";
    }

    var parts = amount.Split(',');

    if (parts.Length > 2)
    {
        return "Invalid format.";
    }

    // Validate dollars
    if (!int.TryParse(parts[0].Replace(" ", ""), out int dollars))
    {
        return "Please enter a valid number.";
    }

    // Validate cents
    int cents = 0;

    if (parts.Length == 2 && parts[1].Length > 0)
    {
        if (!int.TryParse(parts[1], out cents))
        {
            return "Please enter valid cents.";
        }

        // Convert 1 digit cents: 5 -> 50
        if (parts[1].Length == 1)
        {
            cents *= 10;
        }
    }

    // Check requirements
    if (dollars < 0 || dollars > 999_999_999)
    {
        return "Maximum dollars is 999,999,999.";
    }

    if (cents < 0 || cents > 99)
    {
        return "Maximum cents is 99.";
    }


    // Convert after validation
 string currencyName;

switch (currency.ToUpper())
{
    case "USD":
        currencyName = "dollar";
        break;

    case "EUR":
        currencyName = "euro";
        break;

    case "GBP":
        currencyName = "pound";
        break;

    default:
        return "Currency not supported.";
}


if (language.ToLower() == "en")
{
    return _englishConverter.Convert(dollars, cents, currency);
}

if (language.ToLower() == "de")
{
    return _germanConverter.Convert(dollars, cents, currency);
}

 

    return "Language not supported.";
}


}