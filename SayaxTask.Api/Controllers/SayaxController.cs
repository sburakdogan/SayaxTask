using Microsoft.AspNetCore.Mvc;
using SayaxTask.Business.Abstracts;

namespace SayaxTask.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SayaxController : ControllerBase
    {
        private readonly ICalculationService _calculationService;
        private readonly IMeterService _meterService;

        public SayaxController(ICalculationService calculationService, IMeterService meterService)
        {
            _calculationService = calculationService;
            _meterService = meterService;
        }

        [HttpGet]
        public IActionResult GetInvoiceAmount(string meterName)
        {
            if (meterName == null)
                return BadRequest("Lütfen bir sayaç adý giriniz. (S1, S2, S3)");

            var meterInfo = _meterService.GetMeterInfo(meterName.ToUpper());

            var energyCost = _calculationService.CalculateEnergyCost(meterInfo);
            var distributionCost = _calculationService.CalculateDistributionCost(meterInfo.TariffName);
            var btvCost = _calculationService.CalculateBTV(energyCost, 1);

            return Ok(energyCost + distributionCost + btvCost);
        }
    }
}
