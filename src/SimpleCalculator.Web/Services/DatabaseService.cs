using SimpleCalculator.Web.Services.Interfaces;
using System.Linq;
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
        var calculationResultQuery = 
            (from calculationResultEntity in _context.CalculationResultEntities
            orderby calculationResultEntity.Id descending
            select calculationResultEntity)
            .Take(5);

        var calculationResultEntities = calculationResultQuery.ToList();
        model.Result = _mapper.Map<List<CalculationEntityModel>>(calculationResultEntities);
    }
}
