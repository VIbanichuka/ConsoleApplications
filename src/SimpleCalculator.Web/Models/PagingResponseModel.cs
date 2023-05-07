namespace SimpleCalculator.Web.Models;

public class PagingResponseModel
{
    public PagingResponseModel()
    {
        CalcResults = new List<CalculationEntityModel>();
    }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public List<CalculationEntityModel> CalcResults { get; set; }
}
