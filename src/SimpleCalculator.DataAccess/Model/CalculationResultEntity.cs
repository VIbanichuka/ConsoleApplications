namespace SimpleCalculator.DataAccess.Model;

public class CalculationResultEntity
{
    public string? MathOperator { get; set; }
    public int Id { get; set; }
    public double FirstNumber { get; set; }
    public double SecondNumber { get; set; }
    public double Result { get; set; }
}
