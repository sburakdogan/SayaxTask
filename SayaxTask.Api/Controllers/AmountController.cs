using Microsoft.AspNetCore.Mvc;
using SayaxTask.Business.Abstracts;
using SayaxTask.Api.Factory;

namespace SayaxTask.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AmountController : ControllerBase
    {
        private readonly CalculationServiceFactory _calculationServiceFactory;
        private readonly IMeterService _meterService;

        public AmountController(CalculationServiceFactory calculationServiceFactory, IMeterService meterService)
        {
            _calculationServiceFactory = calculationServiceFactory;
            _meterService = meterService;
        }

        [HttpGet("customer")]
        public IActionResult GetInvoiceAmount(string meterName)
        {
            if (meterName == null)
                return BadRequest("Lütfen bir sayaç adý giriniz. (S1, S2, S3)");

            var meterInfo = _meterService.GetMeterInfo(meterName.ToUpper());
            if (meterInfo is null)
                return NotFound("Sayaç bulunamadý.");

            var calculationService = _calculationServiceFactory.CreateCalculationService(meterInfo.MeterName);

            var energyCost = calculationService.CalculateEnergyCost(meterInfo);
            var distributionCost = calculationService.CalculateDistributionCost(meterInfo.TariffName);
            var btvCost = calculationService.CalculateBTV(energyCost, meterInfo.BTV);

            var totalAmount = (energyCost + distributionCost + btvCost) * (1 + meterInfo.KDV / 100);

            return Ok(totalAmount.ToString("C2", new System.Globalization.CultureInfo("tr-TR")));
        }
    }
}
