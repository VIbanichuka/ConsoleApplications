namespace SimpleCalculator.Web.Models;

public class PagingResponseModel
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public List<CalculationEntityModel> CalcResults { get; set; } = new List<CalculationEntityModel>();
}
