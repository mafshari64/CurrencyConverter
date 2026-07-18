using Xunit;
using CurrencyConverter.API.Converters;

namespace CurrencyConverter.Tests;

public class MaximumValueTests
{
    [Fact]
    public void Convert_MaximumValue_ReturnsCorrectResult()
    {
        var converter = new EnglishConverter();

        var result = converter.Convert(
            999999999,
            99,
            "USD");

        Assert.Contains("million", result);
        Assert.Contains("ninety-nine cents", result);
    }
}