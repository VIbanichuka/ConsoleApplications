namespace SimpleCalculator.Web.Models;

public class CalculationPageModel
{
    public CalculationPageModel()
    {
        Input = new CalculationInputModel();
        Result = new List<CalculationEntityModel>();
    }
    public CalculationInputModel Input { get; set; }
    public List<CalculationEntityModel>? Result { get; set; }
}
