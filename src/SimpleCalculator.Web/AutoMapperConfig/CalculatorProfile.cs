using AutoMapper;
using SimpleCalculator.DataAccess.Model;
using SimpleCalculator.Web.Models;
namespace SimpleCalculator.Web.AutoMapperConfig;

public class CalculatorProfile: Profile
{
    public CalculatorProfile()
    {
        CreateMap<CalculationResultEntity, CalculationInputModel>().ReverseMap();
        CreateMap<CalculationResultEntity, CalculationEntityModel>().ReverseMap();
    }
}
