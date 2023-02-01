using Moq;
using Calculations;
using SimpleCalculator.Web.Models;
using SimpleCalculator.Web.Services;
namespace SimpleCalculator.Test.MockTest;

public class CalculationServiceTests
{
    [Fact]
    public void Add_Returns_AdditionOfTwoNumbers()
    {
        var calculationInputModel = new CalculationInputModel() { FirstNumber = 40, SecondNumber = 5, Result = 9 };
        var addServiceStub = new Mock<IAddition>();
        addServiceStub.Setup(x => x.Add(40, 5)).Returns(45);
        var calculationService = new CalculationService(null, null, null, addServiceStub.Object, null, null);

        var expected = calculationService.AddService(calculationInputModel);

        addServiceStub.VerifyAll();
    }

    [Fact]
    public void Multiply_Returns_MultiplicationOfTwoNumbers()
    {
        var calculationInputModel = new CalculationInputModel() { FirstNumber = 5, SecondNumber = 2, Result = 10 };
        var multiplicationStub = new Mock<IMultiplication>();
        multiplicationStub.Setup(x => x.Multiply(5, 2)).Returns(10);
        var calculationService = new CalculationService(multiplicationStub.Object, null, null, null, null, null);

        var actual = calculationService.MultiplyService(calculationInputModel);

        Assert.Equal(10, actual);
    }

    [Fact]
    public void Divide_Returns_DivisionOfTwoNumbers()
    {
        var calculationInputModel = new CalculationInputModel() { FirstNumber = 12, SecondNumber = 3, Result = 4 };
        var divisionStub = new Mock<IDivision>();
        divisionStub.Setup(x => x.Divide(12, 3)).Returns(4);
        var calculationService = new CalculationService(null, divisionStub.Object, null, null, null, null);

        var actual = calculationService.DivideService(calculationInputModel);

        Assert.Equal(4, actual);
    }

    [Fact]
    public void Subtract_returns_SubtractionOfTwoNumbers()
    {
        var calculationInputModel = new CalculationInputModel() { FirstNumber = 3, SecondNumber = 1, Result = 2 };
        var subtractionStub = new Mock<ISubtraction>();
        subtractionStub.Setup(x => x.Subtract(3, 1)).Returns(2);
        var calculationService = new CalculationService(null, null, subtractionStub.Object, null, null, null);

        var actual = calculationService.SubtractService(calculationInputModel);

        Assert.Equal(2, actual);
    }
}
