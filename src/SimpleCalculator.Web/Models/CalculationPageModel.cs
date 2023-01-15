namespace SimpleCalculator.Web.Models;

public class CalculationPageModel
{
    public CalculationInputModel Input { get; set; }
    public List<CalculationEntityModel>? Result { get; set; }
}
