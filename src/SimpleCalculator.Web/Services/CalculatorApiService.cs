using AutoMapper;
using SimpleCalculator.Web.Models;
using SimpleCalculator.Web.Services.Interfaces;
using SimpleCalculator.DataAccess.Data;
namespace SimpleCalculator.Web.Services;

public class CalculatorApiService : ICalculatorApiService
{
    private readonly IMapper _mapper;
    private readonly CalculatorDbContext _context;

    public CalculatorApiService(CalculatorDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public PagingResponseModel GetCalculatorResponse(int page, int pageSize)
    {
        var totalCount = _context.CalculationResultEntities.Count();
        var pageCount = totalCount / pageSize;

        var calculationResults = _context.CalculationResultEntities
           .OrderByDescending(result => result.Id)
           .Skip((page - 1) * pageSize)
           .Take(pageSize)
           .ToList();

        var response = new PagingResponseModel
        {
            PageSize = pageSize,
            TotalPages = pageCount,
            CurrentPage = page,
            TotalCount = totalCount,
            CalcResults = _mapper.Map<List<CalculationEntityModel>>(calculationResults)
        };
        return response;
    }
}
