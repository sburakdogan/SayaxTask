﻿using SayaxTask.Business.Abstracts;
using SayaxTask.Business.Constants;
using SayaxTask.Business.Dtos;

namespace SayaxTask.Business.Services
{
    public class S1CalculationService : BaseCalculationService
    {
        private readonly IExcelReaderService _excelReaderService;

        public S1CalculationService(IExcelReaderService excelReaderService)
        {
            _excelReaderService = excelReaderService;
        }

        public override decimal CalculateEnergyCost(MeterInfoDto meterInfo)
        {
            var totalEnergyCost = 0.0m;
            var totalPTFCost = 0.0m;
            var totalYEKCost = 0.0m;

            var consuptions = _excelReaderService.GetMeterConsuptions(SheetConstants.S1Consuption);
            var allPriceInfo = _excelReaderService.GetAllPriceInfo();

            foreach (var consuption in consuptions)
            {
                var ptf = allPriceInfo.FirstOrDefault(x => x.Date == consuption.CombinedDateTime()).PTF;
                totalPTFCost += (ptf * consuption.Cost);
                totalYEKCost += (PriceConstants.YEK * consuption.Cost);
            }

            totalEnergyCost = (totalPTFCost + totalYEKCost) * (1 + decimal.Parse(meterInfo.CommissionOrDiscount));
            return totalEnergyCost;
        }
    }
}
