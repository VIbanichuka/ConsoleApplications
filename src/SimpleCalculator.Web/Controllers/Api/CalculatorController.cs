using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.Web.Services.Interfaces;
namespace SimpleCalculator.Web.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ICalculationResultsApiService _calculationResultsApiService;
    public CalculatorController(ICalculationResultsApiService calculationResultsApiService)
    {
        _calculationResultsApiService = calculationResultsApiService;
    }

    [HttpGet]
    public IActionResult GetCalculationResults(int page = 1, int pageSize = 10)
    {
        var response = _calculationResultsApiService.GetCalculationResultsPage(page, pageSize);
        if (response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }
}
