using SimpleCalculator.Web.Models;
namespace SimpleCalculator.Web.Services.Interfaces;

public interface ICalculationResultsApiService
{
    PagingResponseModel GetCalculationResultsPage(int page, int pageSize);
}
