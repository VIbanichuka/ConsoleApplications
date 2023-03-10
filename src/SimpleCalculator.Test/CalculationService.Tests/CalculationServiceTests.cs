using Moq;
using SimpleCalculator.Web.AutoMapperConfig;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Calculations;
using SimpleCalculator.Web.Models;
using SimpleCalculator.Web.Services;
using SimpleCalculator.DataAccess.Data;
using SimpleCalculator.DataAccess.Model;
namespace SimpleCalculator.Test.MockTest;

public class CalculationServiceTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IAddition> _additionServiceMock;
    private readonly Mock<ISubtraction> _subtractionServiceMock;
    private readonly Mock<IMultiplication> _multiplicationServiceMock;
    private readonly Mock<IDivision> _divisionServiceMock;

    public CalculationServiceTests()
    {
        var profile = new CalculatorProfile();
        var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
        _mapper = new Mapper(config);

        _divisionServiceMock = new Mock<IDivision>();
        _additionServiceMock = new Mock<IAddition>();
        _subtractionServiceMock = new Mock<ISubtraction>();
        _multiplicationServiceMock = new Mock<IMultiplication>();
    }

    [Fact]
    public void AddToDbService_Should_Save_Entities()
    {
        var passedEnum = MathOperatorEnum.Add;
        var model = new CalculationInputModel();
        var entities = _mapper.Map<CalculationResultEntity>(model);
        entities.MathOperator = passedEnum.ToString();

        var mockDbSet = new Mock<DbSet<CalculationResultEntity>>();
        var mockContext = new Mock<CalculatorDbContext>();
        mockContext.Setup(m => m.CalculationResultEntities).Returns(mockDbSet.Object);

        mockContext.Object.CalculationResultEntities.Add(entities);
        var service = new CalculationService(_multiplicationServiceMock.Object, _divisionServiceMock.Object, _subtractionServiceMock.Object, _additionServiceMock.Object, mockContext.Object, _mapper);
        service.AddToDbService(model, passedEnum);

        mockDbSet.Verify(x => x.Add(It.IsAny<CalculationResultEntity>()), Times.Once());
        mockContext.Verify(x => x.SaveChanges(), Times.Once());
    }
}