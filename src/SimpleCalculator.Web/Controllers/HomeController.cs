using System.Diagnostics;
using SimpleCalculator.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.Web.Models;
using SimpleCalculator.DataAccess.Data;

namespace SimpleCalculator.Web.Controllers;

public class HomeController : Controller
{
    private readonly ICalculationService<CalculationInputModel> _service;
    private readonly IDatabaseService<CalculationPageModel> _dataService;
    private readonly CalculatorDbContext _context;

    public HomeController(ICalculationService<CalculationInputModel> service, IDatabaseService<CalculationPageModel> dataService, CalculatorDbContext context)
    {
        _dataService = dataService;
        _service = service;
        _context = context;
    }

    public IActionResult Index(CalculationPageModel model)
    {
        model.Input = new CalculationInputModel();
        _dataService.GetCalculationResult(model);
        return View(model);
    }

    [HttpPost]
    public IActionResult Add(CalculationPageModel model)
    {
        _service.Add(model.Input);
        _dataService.GetCalculationResult(model);
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult Subtract(CalculationPageModel model)
    {
        _service.Subtract(model.Input);
        _dataService.GetCalculationResult(model);
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult Multiply(CalculationPageModel model)
    {
        _service.Multiply(model.Input);
        _dataService.GetCalculationResult(model);
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult Divide(CalculationPageModel model)
    {
        if (model.Input.SecondNumber == 0)
        {
            ModelState.AddModelError("SecondNumber", "Unable to divide by zero.");
        }
        else
        {
            _service.Divide(model.Input);
        }
        _dataService.GetCalculationResult(model);
        return View("Index", model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
