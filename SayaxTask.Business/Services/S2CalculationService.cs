using SayaxTask.Business.Abstracts;
using SayaxTask.Business.Constants;
using SayaxTask.Business.Dtos;

namespace SayaxTask.Business.Services
{
    public class S2CalculationService : BaseCalculationService
    {
        private readonly IMeterService _meterService;
        private readonly IPriceInfoService _priceInfoService;

        public S2CalculationService(IMeterService meterService, IPriceInfoService priceInfoService)
        {
            _meterService = meterService;
            _priceInfoService = priceInfoService;
        }

        public override decimal CalculateEnergyCost(MeterInfoDto meterInfo)
        {
            var totalEnergyCost = 0.0m;
            var totalPTFCost = 0.0m;

            var consuptions = _meterService.GetMeterConsuptions(SheetConstants.S1Consuption);
            var allPriceInfo = _priceInfoService.GetAllPriceInfo();

            foreach (var consuption in consuptions)
            {
                var ptf = allPriceInfo.FirstOrDefault(x => x.Date == consuption.CombinedDateTime()).PTF;
                totalPTFCost += (ptf * consuption.Cost);
            }

            var tariffPrice = PriceConstants.GetEnergyTariffPriceByName(meterInfo.TariffName);
            totalEnergyCost = totalPTFCost + PriceConstants.YEK + tariffPrice + meterInfo.GetCommissionOrPercentage();

            return totalEnergyCost;
        }
    }
}
