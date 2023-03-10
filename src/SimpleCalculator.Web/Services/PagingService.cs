using SimpleCalculator.Web.Services.Interfaces;
using AutoMapper;
using SimpleCalculator.DataAccess.Data;
using SimpleCalculator.Web.Models;
namespace SimpleCalculator.Web.Services;

public class PagingService : IPagingService<CalculationPageModel>
{
    private const int pageSize = 5;
    private readonly IMapper _mapper;
    private readonly CalculatorDbContext _context;
    public PagingService(CalculatorDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public void GetPagedCalculationResults(CalculationPageModel model)
    {
        var calculationResultQuery = _context.CalculationResultEntities
            .OrderByDescending(calcResult => calcResult.Id)
            .Take(pageSize)
            .ToList();
        model.Result = _mapper.Map<List<CalculationEntityModel>>(calculationResultQuery);
    }
}
