namespace CurrencyConverter.API.Models;

public class ConversionRequest
{
    public string Amount { get; set; } = "";

    public string Language { get; set; } = "en";

    public string Currency { get; set; } = "USD";
}