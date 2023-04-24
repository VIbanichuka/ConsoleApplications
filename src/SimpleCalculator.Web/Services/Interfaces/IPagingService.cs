namespace SimpleCalculator.Web.Services.Interfaces;

public interface IPagingService<T>
{
    void GetPagedCalculationResults(T model);
}
