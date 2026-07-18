using Microsoft.AspNetCore.Mvc;
using CurrencyConverter.API.Models;
using CurrencyConverter.API.Services;

namespace CurrencyConverter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConversionController : ControllerBase
{
    private readonly CurrencyConverterService _converterService;

    public ConversionController(CurrencyConverterService converterService)
    {
        _converterService = converterService;
    }

    [HttpPost]
    public ActionResult<ConversionResponse> Convert([FromBody] ConversionRequest request)
    {
        var result = _converterService.Convert(
    request.Amount,
    request.Language,
    request.Currency
);

        return Ok(new ConversionResponse
        {
            Result = result
        });
    }
}