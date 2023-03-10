using AutoMapper;
using Moq;
using SimpleCalculator.Web.Services;
using SimpleCalculator.Web.AutoMapperConfig;
using SimpleCalculator.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using SimpleCalculator.DataAccess.Data;
namespace SimpleCalculator.Test.CalculationService_Tests;

public class CalculatorApiServiceTest
{
    private readonly IMapper _mapper;
    public CalculatorApiServiceTest()
    {
        var profile = new CalculatorProfile();
        var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
        _mapper = new Mapper(config);
    }

    [Fact]
    public void GetCalculatorResponse()
    {

        var data = new List<CalculationResultEntity>
        {
            new CalculationResultEntity { Id = 1, MathOperator = "Add", FirstNumber = 12, SecondNumber = 10, Result = 22},
            new CalculationResultEntity {Id = 2, MathOperator = "Subtract", FirstNumber = 12, SecondNumber = 10, Result = 2},
            new CalculationResultEntity {Id = 3, MathOperator = "Add", FirstNumber = 5, SecondNumber = 5, Result = 10},
        }.AsQueryable();

        var mockDbSet = new Mock<DbSet<CalculationResultEntity>>();
        mockDbSet.As<IQueryable<CalculationResultEntity>>().Setup(m => m.Provider).Returns(data.Provider);
        mockDbSet.As<IQueryable<CalculationResultEntity>>().Setup(m => m.Expression).Returns(data.Expression);
        mockDbSet.As<IQueryable<CalculationResultEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockDbSet.As<IQueryable<CalculationResultEntity>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        var mockContext = new Mock<CalculatorDbContext>();
        mockContext.Setup(x => x.CalculationResultEntities).Returns(mockDbSet.Object);

        var service = new CalculatorApiService(mockContext.Object, _mapper);
        int pageSize = 3;
        int page = 1;
        var totalCount = data.Count();
        var pageCount = totalCount / pageSize;

        var calculationResults = service.GetCalculatorResponse(page, pageSize);

        Assert.Equal(pageSize, calculationResults.PageSize);
        Assert.Equal(page, calculationResults.CurrentPage);
        Assert.Equal(totalCount, calculationResults.TotalCount);
        Assert.Equal(pageCount, calculationResults.TotalPages);
    }
}
