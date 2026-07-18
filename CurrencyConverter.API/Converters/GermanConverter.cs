namespace CurrencyConverter.API.Converters;

public class GermanConverter
{
    private static readonly string[] Ones =
    {
        "null", "eins", "zwei", "drei", "vier",
        "fünf", "sechs", "sieben", "acht",
        "neun", "zehn", "elf", "zwölf",
        "dreizehn", "vierzehn", "fünfzehn",
        "sechzehn", "siebzehn", "achtzehn",
        "neunzehn"
    };

    private static readonly string[] Tens =
    {
        "", "", "zwanzig", "dreißig",
        "vierzig", "fünfzig", "sechzig",
        "siebzig", "achtzig", "neunzig"
    };


public string Convert(int dollars, int cents, string currency)
{
    string currencyName = currency.ToUpper() switch
    {
        "EUR" => "Euro",
        "GBP" => "Pfund",
        _ => "Dollar"
    };

    string result;

    // German currency singular
    if (dollars == 1)
    {
        result = $"ein {currencyName}";
    }
    else
    {
        result = $"{ConvertNumber(dollars)} {currencyName}";
    }


    if (cents > 0)
    {
        if (cents == 1)
            result += " und ein Cent";
        else
            result += $" und {ConvertNumber(cents)} Cent";
    }

    return result;
}
private string ConvertNumber(int number)
{
    if (number < 20)
        return Ones[number];

    if (number < 100)
    {
        int ones = number % 10;
        int tens = number / 10;

        if (ones == 0)
            return Tens[tens];

        string prefix = ones == 1 ? "ein" : Ones[ones];

        return $"{prefix}und{Tens[tens]}";
    }

    if (number < 1000)
    {
        int hundreds = number / 100;
        int rest = number % 100;

        string result = hundreds == 1
            ? "einhundert"
            : $"{Ones[hundreds]}hundert";

        if (rest > 0)
            result += ConvertNumber(rest);

        return result;
    }

    if (number < 1_000_000)
    {
        int thousands = number / 1000;
        int remainder = number % 1000;

        string result;

        if (thousands == 1)
            result = "eintausend";
        else
            result = $"{ConvertNumber(thousands)}tausend";

        if (remainder > 0)
            result += ConvertNumber(remainder);

        return result;
    }

    if (number < 1_000_000_000)
    {
        int millions = number / 1_000_000;
        int remainder = number % 1_000_000;

        string result;

        if (millions == 1)
            result = "eine Million";
        else
            result = $"{ConvertNumber(millions)} Millionen";

        if (remainder > 0)
            result += " " + ConvertNumber(remainder);

        return result;
    }

    return "Zahl zu groß";
}

}