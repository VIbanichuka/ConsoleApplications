namespace SimpleCalculator.Web.Services.Interfaces;

public interface ICalculationService<T>
{
    double MultiplyService(T model);
    double AddService(T model);
    double SubtractService(T model);
    double DivideService(T model);
    void AddToDbService(T model, MathOperatorEnum mathOperator);
}
