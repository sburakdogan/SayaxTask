using SayaxTask.Business.Abstracts;
using SayaxTask.Business.Constants;
using SayaxTask.Business.Dtos;

namespace SayaxTask.Business.Services
{
    public class S3CalculationService : BaseCalculationService
    {
        private readonly IMeterService _meterService;
        private readonly IPriceInfoService _priceInfoService;

        public S3CalculationService(IMeterService meterService, IPriceInfoService priceInfoService)
        {
            _meterService = meterService;
            _priceInfoService = priceInfoService;
        }

        public override decimal CalculateEnergyCost(MeterInfoDto meterInfo)
        {
            var totalEnergyCost = 0.0m;
            var totalTariffCost = 0.0m;

            var consuptions = _meterService.GetMeterConsuptions(SheetConstants.S1Consuption);
            var allPriceInfo = _priceInfoService.GetAllPriceInfo();
            var tariffPrice = PriceConstants.GetEnergyTariffPriceByName(meterInfo.TariffName);

            foreach (var consuption in consuptions)
            {
                totalTariffCost += (tariffPrice * consuption.Cost);
            }

            totalEnergyCost = totalTariffCost - (totalTariffCost * meterInfo.CommissionOrDiscount);
            return totalEnergyCost;
        }
    }
}
