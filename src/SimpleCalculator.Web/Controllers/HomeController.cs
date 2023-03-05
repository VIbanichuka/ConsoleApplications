using System.Diagnostics;
using SimpleCalculator.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.Web.Models;
using SimpleCalculator.DataAccess.Data;
using AutoMapper;

namespace SimpleCalculator.Web.Controllers;

public class HomeController : Controller
{
    private readonly ICalculationService<CalculationInputModel> _service;
    private readonly IDatabaseService<CalculationPageModel> _dataService;
    private readonly CalculatorDbContext _context;
    private readonly IMapper _mapper;
    public HomeController(ICalculationService<CalculationInputModel> service, IMapper mapper, IDatabaseService<CalculationPageModel> dataService, CalculatorDbContext context)
    {
        _dataService = dataService;
        _service = service;
        _context = context;
        _mapper = mapper;
    }

    public IActionResult Index(CalculationPageModel model)
    {
        _dataService.GetCalculationResult(model);
        return View(model);
    }

    [HttpPost]
    public IActionResult Add(CalculationPageModel model)
    {
        _service.AddService(model.Input);
        _dataService.GetCalculationResult(model);
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult Subtract(CalculationPageModel model)
    {
        _service.SubtractService(model.Input);
        _dataService.GetCalculationResult(model);
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult Multiply(CalculationPageModel model)
    {
        _service.MultiplyService(model.Input);
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
            _service.DivideService(model.Input);
        }
        _dataService.GetCalculationResult(model);
        return View("Index", model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult CalculationResults()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
