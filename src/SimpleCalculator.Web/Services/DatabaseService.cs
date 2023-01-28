using SimpleCalculator.Web.Services.Interfaces;
using System.Linq;
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
        var calculationResultQuery = 
            (from calculationResultEntity in _context.CalculationResultEntities
            orderby calculationResultEntity.Id descending
            select calculationResultEntity)
            .Take(5);

        var calculationResultEntities = calculationResultQuery.ToList();
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
