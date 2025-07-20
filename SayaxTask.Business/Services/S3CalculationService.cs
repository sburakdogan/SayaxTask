using SayaxTask.Business.Abstracts;
using SayaxTask.Business.Constants;
using SayaxTask.Business.Dtos;

namespace SayaxTask.Business.Services
{
    public class S3CalculationService : BaseCalculationService
    {
        public override decimal CalculateEnergyCost(MeterInfoDto meterInfo)
        {
            var totalEnergyCost = 0.0m;

            var tariffPrice = PriceConstants.GetEnergyTariffPriceByName(meterInfo.TariffName);
            totalEnergyCost = tariffPrice - (tariffPrice * meterInfo.GetCommissionOrPercentage() / 100);

            return totalEnergyCost;
        }
    }
}
