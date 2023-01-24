using SimpleCalculator.Web.Services.Interfaces;
using SimpleCalculator.DataAccess.Data;
using SimpleCalculator.Web.Models;
namespace SimpleCalculator.Web.Services;

public class DatabaseService : IDatabaseService<CalculationPageModel>
{
    private readonly CalculatorDbContext _context;
    public DatabaseService(CalculatorDbContext context)
    {
        _context = context;
    }
    public void GetCalculationResult(CalculationPageModel model)
    {
        var calculationResultEntities = _context.CalculationResultEntities.ToList();
        model.Result = new List<CalculationEntityModel>();

        if (calculationResultEntities != null)
        {
            foreach (var entity in calculationResultEntities)
            {
                var entityModel = new CalculationEntityModel()
                {
                    Id = entity.Id,
                    MathOperator = entity.MathOperator,
                    FirstNumber = entity.FirstNumber,
                    SecondNumber = entity.SecondNumber,
                    Result = entity.Result
                };
                model.Result.Add(entityModel);
            }
        }
    }
}
