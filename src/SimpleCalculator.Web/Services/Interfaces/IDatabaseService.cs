namespace SimpleCalculator.Web.Services.Interfaces;

public interface IDatabaseService<T>
{
    void GetCalculationResult(T model);
}
