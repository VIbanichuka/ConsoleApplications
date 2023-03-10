using SimpleCalculator.Web.Models;
namespace SimpleCalculator.Web.Services.Interfaces;

public interface IApiControllerService
{
    PagingResponseModel GetCalculatorResponse(int page, int pageSize);
}
