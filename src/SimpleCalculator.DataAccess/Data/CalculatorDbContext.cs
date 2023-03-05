using Microsoft.EntityFrameworkCore;
using SimpleCalculator.DataAccess.Model;
namespace SimpleCalculator.DataAccess.Data;

public class CalculatorDbContext : DbContext
{
    public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options)
    {

    }
    public DbSet<CalculationResultEntity> CalculationResultEntities { get; set; }
}

