namespace CurrencyConverter.API.Converters;

public class EnglishConverter
{
    private static readonly string[] Ones =
    {
        "zero", "one", "two", "three", "four",
        "five", "six", "seven", "eight", "nine",
        "ten", "eleven", "twelve", "thirteen",
        "fourteen", "fifteen", "sixteen",
        "seventeen", "eighteen", "nineteen"
    };

    private static readonly string[] Tens =
    {
        "", "", "twenty", "thirty", "forty",
        "fifty", "sixty", "seventy",
        "eighty", "ninety"
    };


public string Convert(int dollars, int cents, string currency)
{
string currencyName = currency.ToUpper() switch
{
    "USD" => dollars == 1 ? "dollar" : "dollars",
    "EUR" => dollars == 1 ? "euro" : "euros",
    "GBP" => dollars == 1 ? "pound" : "pounds",
    _ => currency
};

string result = $"{ConvertNumber(dollars)} {currencyName}";


    if (cents > 0)
    {
        if (cents == 1)
            result += $" and {ConvertNumber(cents)} cent";
        else
            result += $" and {ConvertNumber(cents)} cents";
    }

    return result;
}

private string ConvertNumber(int number)
{
    if (number < 20)
    {
        return Ones[number];
    }

    if (number < 100)
    {
        int tens = number / 10;
        int remainder = number % 10;

        if (remainder == 0)
            return Tens[tens];

        return $"{Tens[tens]}-{Ones[remainder]}";
    }

    if (number < 1000)
    {
        int hundreds = number / 100;
        int remainder = number % 100;

        if (remainder == 0)
            return $"{Ones[hundreds]} hundred";

        return $"{Ones[hundreds]} hundred {ConvertNumber(remainder)}";
    }

    if (number < 1_000_000)
    {
        int thousands = number / 1000;
        int remainder = number % 1000;

        if (remainder == 0)
            return $"{ConvertNumber(thousands)} thousand";

        return $"{ConvertNumber(thousands)} thousand {ConvertNumber(remainder)}";
    }

    if (number < 1_000_000_000)
    {
        int millions = number / 1_000_000;
        int remainder = number % 1_000_000;

        if (remainder == 0)
            return $"{ConvertNumber(millions)} million";

        return $"{ConvertNumber(millions)} million {ConvertNumber(remainder)}";
    }

    return "number too large";
}

}