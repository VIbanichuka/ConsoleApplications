using Microsoft.EntityFrameworkCore;
using SimpleCalculator.DataAccess.Model;
namespace SimpleCalculator.DataAccess.Data;

public class CalculatorDbContext : DbContext
{
    public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options)
    {

    }

    public CalculatorDbContext() { }
    public virtual DbSet<CalculationResultEntity> CalculationResultEntities { get; set; }
}

