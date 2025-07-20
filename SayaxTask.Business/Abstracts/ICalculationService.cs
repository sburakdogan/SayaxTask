using SayaxTask.Business.Dtos;

namespace SayaxTask.Business.Abstracts
{
    public interface ICalculationService
    {
        decimal CalculateEnergyCost(MeterInfoDto meterInfo);
        decimal CalculateDistributionCost(string tariffName);
        decimal CalculateBTV(decimal totalEnergyCost, int btvPercentage);
    }
}
