using SimpleCalculator.Web.Services.Interfaces;
using AutoMapper;
using SimpleCalculator.DataAccess.Data;
using SimpleCalculator.Web.Models;
namespace SimpleCalculator.Web.Services;

public class DatabaseService : IDatabaseService<CalculationPageModel>
{
    private readonly IMapper _mapper;
    private readonly CalculatorDbContext _context;
    public DatabaseService(CalculatorDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public void GetCalculationResult(CalculationPageModel model)
    {
        var calculationResultQuery = _context.CalculationResultEntities
            .OrderByDescending(calcResult => calcResult.Id)
            .Take(5)
            .ToList();
        model.Result = _mapper.Map<List<CalculationEntityModel>>(calculationResultQuery);
    }
}
