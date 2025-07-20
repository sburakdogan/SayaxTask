using SayaxTask.Business.Constants;
using SayaxTask.Business.Dtos;

namespace SayaxTask.Business.Abstracts
{
    public abstract class BaseCalculationService
    {
        public abstract decimal CalculateEnergyCost(MeterInfoDto meterInfo);

        public decimal CalculateDistributionCost(string tariffName)
        {
            return PriceConstants.GetEnergyTariffPriceByName(tariffName);
        }

        public decimal CalculateBTV(decimal totalEnergyCost, decimal btvPercentage)
        {
            return totalEnergyCost * btvPercentage;
        }
    }
}
