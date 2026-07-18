using Xunit;
using CurrencyConverter.API.Converters;

namespace CurrencyConverter.Tests;

public class EnglishConverterTests
{
    [Fact]
    public void Convert_25Dollars10Cents_ReturnsCorrectText()
    {
        var converter = new EnglishConverter();

        var result = converter.Convert(25, 10, "USD");

        Assert.Equal(
            "twenty-five dollars and ten cents",
            result);
    }
}