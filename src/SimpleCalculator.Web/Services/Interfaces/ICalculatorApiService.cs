using SimpleCalculator.Web.Models;
namespace SimpleCalculator.Web.Services.Interfaces;

public interface ICalculatorApiService
{
    PagingResponseModel GetCalculatorResponse(int page, int pageSize);
}
