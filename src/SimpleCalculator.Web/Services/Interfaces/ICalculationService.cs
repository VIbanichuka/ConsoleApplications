namespace SimpleCalculator.Web.Services.Interfaces;

public interface ICalculationService<T>
{
    double Multiply(T model);
    double Add(T model);
    double Subtract(T model);
    double Divide(T model);
}
