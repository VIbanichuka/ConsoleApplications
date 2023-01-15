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
    public double Add(CalculationInputModel model)
    {
        return model.Result = _addition.Add(model.FirstNumber, model.SecondNumber);
    }

    public double Divide(CalculationInputModel model)
    {
        return model.Result = _division.Divide(model.FirstNumber, model.SecondNumber);
    }

    public double Multiply(CalculationInputModel model)
    {
        return model.Result = _multiplication.Multiply(model.FirstNumber, model.SecondNumber);
    }

    public double Subtract(CalculationInputModel model)
    {
        var entities = _mapper.Map<CalculationResultEntity>(model);
        entities.MathOperator ="-";
        return model.Result = _subtraction.Subtract(model.FirstNumber, model.SecondNumber);
    }
    
    public void AddToDb(CalculationInputModel model)
    {
        var entities = _mapper.Map<CalculationResultEntity>(model);
        _context.Add(entities);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
