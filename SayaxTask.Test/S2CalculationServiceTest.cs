using Moq;
using SayaxTask.Business.Abstracts;
using SayaxTask.Business.Constants;
using SayaxTask.Business.Dtos;
using SayaxTask.Business.Services;

namespace SayaxTask.Test
{
    public class S2CalculationServiceTest
    {
        private readonly Mock<IExcelReaderService> _excelReaderService;
        private readonly S2CalculationService _calculationService;

        public S2CalculationServiceTest()
        {
            _excelReaderService = new Mock<IExcelReaderService>();
            _calculationService = new S2CalculationService(_excelReaderService.Object);
        }

        [Fact]
        public void CalculateEnergyCost_ShouldReturnCorrectEnergyCost()
        {
            var yek = PriceConstants.YEK;
            var meterInfo = GetMeterInfoData();
            var meterConsuptions = GetMeterConsuptions();
            var priceInfo = GetPriceInfo();

            _excelReaderService.Setup(x => x.GetMeterConsuptions(SheetConstants.S2Consuption)).Returns(meterConsuptions);
            _excelReaderService.Setup(x => x.GetAllPriceInfo()).Returns(priceInfo);

            var ptfCost = (0.551m * 1575m) + (0.522m * 1399.99m) + (0.552m * 1400) + (0.501m * 1399.99m);
            var yekCost = (0.551m + 0.522m + 0.552m + 0.501m) * yek;

            var expectedTotalEnergyCost = ptfCost + yekCost + decimal.Parse(meterInfo.CommissionOrDiscount.Replace(" TL", ""));

            var result = _calculationService.CalculateEnergyCost(meterInfo);

            Assert.Equal(expectedTotalEnergyCost, result);
        }

        private MeterInfoDto GetMeterInfoData()
        {
            return new MeterInfoDto
            {
                MeterName = "S2",
                Method = "PTF + YEK + Komisyon",
                CommissionOrDiscount = "20 TL",
                BTV = 5,
                KDV = 10,
                TariffName = "Ticarethane",
                Municipality = "Kadıköy"
            };
        }

        private List<MeterConsuptionDto> GetMeterConsuptions()
        {
            return new List<MeterConsuptionDto>
            {
                new() {
                    MeterName = "S2",
                    Date = "2024-07-01 00:00:00.000",
                    Time = 1,
                    Cost = 0.551m
                },
                new() {
                    MeterName = "S2",
                    Date = "2024-07-01 00:00:00.000",
                    Time = 2,
                    Cost = 0.522m
                },
                new() {
                    MeterName = "S2",
                    Date = "2024-07-01 00:00:00.000",
                    Time = 3,
                    Cost = 0.552m
                },
                new() {
                    MeterName = "S2",
                    Date = "2024-07-01 00:00:00.000",
                    Time = 4,
                    Cost = 0.501m
                }
            };
        }

        private List<PriceInfoDto> GetPriceInfo()
        {
            return new List<PriceInfoDto>
            {
                new() {
                    Date = DateTime.Parse("2024-07-01 01:00:00.000"),
                    PTF = 1575
                },
                new() {
                    Date = DateTime.Parse("2024-07-01 02:00:00.000"),
                    PTF = 1399.99m
                },
                new() {
                    Date = DateTime.Parse("2024-07-01 03:00:00.000"),
                    PTF = 1400
                },
                new() {
                    Date = DateTime.Parse("2024-07-01 04:00:00.000"),
                    PTF = 1399.99m
                }
            };
        }
    }
}
