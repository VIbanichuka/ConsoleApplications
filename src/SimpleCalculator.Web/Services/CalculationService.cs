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
    public double AddService(CalculationInputModel model)
    {
        var result = model.Result = _addition.Add(model.FirstNumber, model.SecondNumber);
        AddToDbService(model, MathOperatorEnum.Add);
        return result;
    }

    public double DivideService(CalculationInputModel model)
    {
        var result = model.Result = _division.Divide(model.FirstNumber, model.SecondNumber);
        AddToDbService(model, MathOperatorEnum.Divide);
        return result;
    }

    public double MultiplyService(CalculationInputModel model)
    {
        var result = model.Result = _multiplication.Multiply(model.FirstNumber, model.SecondNumber);
        AddToDbService(model, MathOperatorEnum.Multiply);
        return result;
    }

    public double SubtractService(CalculationInputModel model)
    {
        var result = model.Result = _subtraction.Subtract(model.FirstNumber, model.SecondNumber);
        AddToDbService(model, MathOperatorEnum.Subtract);
        return result;
    }

    public void AddToDbService(CalculationInputModel model, MathOperatorEnum mathOperator)
    {
        var entities = _mapper.Map<CalculationResultEntity>(model);
        entities.MathOperator = mathOperator.ToString();
        _context.Add(entities);
        _context.SaveChanges();
    }
}
