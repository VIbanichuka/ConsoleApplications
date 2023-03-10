namespace SimpleCalculator.Web.Models;

public class CalculationEntityModel
{
    public int Id { get; set; }
    public string? MathOperator { get; set; }
    public double FirstNumber { get; set; }
    public double SecondNumber { get; set; }
    public double Result { get; set; }
}
