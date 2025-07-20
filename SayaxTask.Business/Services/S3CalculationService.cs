using SayaxTask.Business.Abstracts;
using SayaxTask.Business.Constants;
using SayaxTask.Business.Dtos;

namespace SayaxTask.Business.Services
{
    public class S3CalculationService : BaseCalculationService
    {
        private readonly IExcelReaderService _excelReaderService;

        public S3CalculationService(IExcelReaderService excelReaderService)
        {
            _excelReaderService = excelReaderService;
        }

        public override decimal CalculateEnergyCost(MeterInfoDto meterInfo)
        {
            var totalEnergyCost = 0.0m;
            var totalTariffCost = 0.0m;

            var consuptions = _excelReaderService.GetMeterConsuptions(SheetConstants.S3Consuption);
            var tariffPrice = PriceConstants.GetEnergyTariffPriceByName(meterInfo.TariffName);

            foreach (var consuption in consuptions)
            {
                totalTariffCost += (tariffPrice * consuption.Cost);
            }

            totalEnergyCost = totalTariffCost - (totalTariffCost * decimal.Parse(meterInfo.CommissionOrDiscount));
            return totalEnergyCost;
        }
    }
}
