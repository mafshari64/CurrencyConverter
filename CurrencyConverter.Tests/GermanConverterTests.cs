using Xunit;
using CurrencyConverter.API.Converters;

namespace CurrencyConverter.Tests;

public class GermanConverterTests
{
    [Fact]
    public void Convert_GermanEuro_ReturnsCorrectText()
    {
        var converter = new GermanConverter();

        var result = converter.Convert(25, 25, "EUR");

        Assert.Equal(
            "fünfundzwanzig Euro und fünfundzwanzig Cent",
            result);
    }
}