using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.Web.Services.Interfaces;
namespace SimpleCalculator.Web.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ICalculatorApiService _service;
    public CalculatorController(ICalculatorApiService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetCalculationResults(int page = 1, int pageSize = 10)
    {
        var response = _service.GetCalculatorResponse(page, pageSize);
        if (response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }
}
