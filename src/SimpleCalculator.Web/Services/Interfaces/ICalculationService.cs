namespace SimpleCalculator.Web.Services.Interfaces;

public interface ICalculationService<T>
{
    void Multiply(T model);
    void Add(T model);
    void Subtract(T model);
    void Divide(T model);
    void Save();
}
