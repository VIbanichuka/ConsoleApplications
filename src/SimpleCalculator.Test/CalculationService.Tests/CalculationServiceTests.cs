using Moq;
using SimpleCalculator.Web.AutoMapperConfig;
using AutoMapper;
using Calculations;
using SimpleCalculator.Web.Services.Interfaces;
using SimpleCalculator.Web.Models;
using SimpleCalculator.DataAccess.Data;
using SimpleCalculator.DataAccess.Model;
using SimpleCalculator.Web.Services;

namespace SimpleCalculator.Test.MockTest;

public class CalculationServiceTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IAddition> _additionMock;
    private readonly Mock<ISubtraction> _subtractionMock;
    private readonly Mock<IMultiplication> _multiplicationMock;
    private readonly Mock<IDivision> _divisionMock;
    private readonly Mock<CalculatorDbContext> _mockContext;
    private readonly ICalculationService<CalculationInputModel> _calculationService;

    public CalculationServiceTests()
    {
        var profile = new CalculatorProfile();
        var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
        _mapper = new Mapper(config);

        _divisionMock = new Mock<IDivision>();
        _additionMock = new Mock<IAddition>();
        _subtractionMock = new Mock<ISubtraction>();
        _mockContext = new Mock<CalculatorDbContext>();
        _multiplicationMock = new Mock<IMultiplication>();

        _calculationService = new CalculationService(_multiplicationMock.Object, _divisionMock.Object, _subtractionMock.Object, _additionMock.Object, _mockContext.Object, _mapper);
    }

    [Fact]
    public void Add_TwoValuesShouldAdd()
    {
        var input = new CalculationInputModel { FirstNumber = 10, SecondNumber = 5 };
        var expectedResult = 15;
        _additionMock.Setup(x => x.Add(input.FirstNumber, input.SecondNumber)).Returns(expectedResult);

        var result = _calculationService.Add(input);

        Assert.Equal(expectedResult, result);
    }



    [Fact]
    public void Subtract_TwoValuesShouldSubtract()
    {
        var input = new CalculationInputModel { FirstNumber = 10, SecondNumber = 5 };
        var expectedResult = 5;
        _subtractionMock.Setup(x => x.Subtract(input.FirstNumber, input.SecondNumber)).Returns(expectedResult);

        var result = _calculationService.Subtract(input);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Multiply_TwoValuesShouldMultiply()
    {
        var input = new CalculationInputModel { FirstNumber = 10, SecondNumber = 5 };
        var expectedResult = 50;
        _multiplicationMock.Setup(x => x.Multiply(input.FirstNumber, input.SecondNumber)).Returns(expectedResult);

        var result = _calculationService.Multiply(input);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Divide_TwoValuesShouldDivide()
    {
        var input = new CalculationInputModel { FirstNumber = 10, SecondNumber = 5 };
        var expectedResult = 15;
        _divisionMock.Setup(x => x.Divide(input.FirstNumber, input.SecondNumber)).Returns(expectedResult);

        var result = _calculationService.Divide(input);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Add_ShouldCallAddToDb()
    {
        var input = new CalculationInputModel { FirstNumber = 7, SecondNumber = 10 };
        var expectedResult = 17;
        _additionMock.Setup(x => x.Add(input.FirstNumber, input.SecondNumber)).Returns(expectedResult);

        var model = new CalculationInputModel { FirstNumber = 7, SecondNumber = 10 };

        var result = _calculationService.Add(model);

        Assert.Equal(17, result);
        _mockContext.Verify(x => x.Add(It.IsAny<CalculationResultEntity>()), Times.Once);
        _mockContext.Verify(x => x.SaveChanges(), Times.Once);
    }

    [Fact]
    public void Subtract_ShouldCallAddToDb()
    {
        var input = new CalculationInputModel { FirstNumber = 10, SecondNumber = 7 };
        var expectedResult = 3;
        _subtractionMock.Setup(x => x.Subtract(input.FirstNumber, input.SecondNumber)).Returns(expectedResult);

        var model = new CalculationInputModel { FirstNumber = 10, SecondNumber = 7 };

        var result = _calculationService.Subtract(model);

        Assert.Equal(3, result);
        _mockContext.Verify(x => x.Add(It.IsAny<CalculationResultEntity>()), Times.Once);
        _mockContext.Verify(x => x.SaveChanges(), Times.Once);
    }

    [Fact]
    public void Divide_ShouldCallAddToDb()
    {
        var inputs = new CalculationInputModel { FirstNumber = 10, SecondNumber = 5 };
        var expectedResult = 2;
        _divisionMock.Setup(x => x.Divide(inputs.FirstNumber, inputs.SecondNumber)).Returns(expectedResult);

        var model = new CalculationInputModel { FirstNumber = 10, SecondNumber = 5 };

        var result = _calculationService.Divide(model);

        Assert.Equal(2, result);
        _mockContext.Verify(x => x.Add(It.IsAny<CalculationResultEntity>()), Times.Once);
        _mockContext.Verify(x => x.SaveChanges(), Times.Once);
    }

    [Fact]
    public void Multiply_ShouldCallAddToDb()
    {
        var inputs = new CalculationInputModel { FirstNumber = 10, SecondNumber = 5 };
        var expectedResult = 50;
        _multiplicationMock.Setup(x => x.Multiply(inputs.FirstNumber, inputs.SecondNumber)).Returns(expectedResult);

        var model = new CalculationInputModel { FirstNumber = 10, SecondNumber = 5 };

        var result = _calculationService.Multiply(model);

        Assert.Equal(50, result);
        _mockContext.Verify(x => x.Add(It.IsAny<CalculationResultEntity>()), Times.Once);
        _mockContext.Verify(x => x.SaveChanges(), Times.Once);
    }
}