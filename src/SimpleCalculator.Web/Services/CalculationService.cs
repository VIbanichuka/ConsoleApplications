using Calculations;
using AutoMapper;
using SimpleCalculator.Web.Services.Interfaces;
using SimpleCalculator.DataAccess.Data;
using SimpleCalculator.DataAccess.Model;
using SimpleCalculator.Web.Models;
namespace SimpleCalculator.Web.Services;

public class CalculationService : ICalculationService<CalculationInputModel>
{
    private readonly IAddition _addition;
    private readonly ISubtraction _subtraction;
    private readonly IDivision _division;
    private readonly IMultiplication _multiplication;
    private readonly IMapper _mapper;
    private readonly CalculatorDbContext _context;

    public CalculationService(IMultiplication multiplication, IDivision division, ISubtraction subtraction,
        IAddition addition, CalculatorDbContext context, IMapper mapper)
    {
        _addition = addition;
        _context = context;
        _division = division;
        _mapper = mapper;
        _multiplication = multiplication;
        _subtraction = subtraction;
    }
    public void Add(CalculationInputModel model)
    {
        model.Result = _addition.Add(model.FirstNumber, model.SecondNumber);
        var entities = _mapper.Map<CalculationResultEntity>(model);
        entities.MathOperator = "+";
        _context.CalculationResultEntities.Add(entities);
    }

    public void Divide(CalculationInputModel model)
    {
        model.Result = _division.Divide(model.FirstNumber, model.SecondNumber);
        var entities = _mapper.Map<CalculationResultEntity>(model);
        entities.MathOperator = "/";
        _context.CalculationResultEntities.Add(entities);
    }

    public void Multiply(CalculationInputModel model)
    {
        model.Result = _multiplication.Multiply(model.FirstNumber, model.SecondNumber);
        var entities = _mapper.Map<CalculationResultEntity>(model);
        entities.MathOperator = "*";
        _context.CalculationResultEntities.Add(entities);
    }

    public void Subtract(CalculationInputModel model)
    {
        model.Result = _subtraction.Subtract(model.FirstNumber, model.SecondNumber);
        var entities = _mapper.Map<CalculationResultEntity>(model);
        entities.MathOperator = "-";
        _context.CalculationResultEntities.Add(entities);
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }
}
