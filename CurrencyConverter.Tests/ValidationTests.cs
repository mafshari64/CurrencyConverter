using Xunit;
using CurrencyConverter.API.Services;
using CurrencyConverter.API.Converters;

namespace CurrencyConverter.Tests;

public class ValidationTests
{
    [Fact]
    public void Convert_InvalidInput_ReturnsErrorMessage()
    {
        var service = new CurrencyConverterService(
            new EnglishConverter(),
            new GermanConverter());

        var result = service.Convert("abc", "en", "USD");

        Assert.Equal(
            "Please enter a valid number.",
            result);
    }
}