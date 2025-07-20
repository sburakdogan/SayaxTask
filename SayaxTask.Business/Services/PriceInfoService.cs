using SayaxTask.Business.Abstracts;
using SayaxTask.Business.Constants;
using SayaxTask.Business.Dtos;
using SayaxTask.Business.Helper;

namespace SayaxTask.Business.Services
{
    public class PriceInfoService : IPriceInfoService
    {
        private readonly IExcelReaderService _excelReaderService;
        private readonly ReflectionHelper _reflectionHelper;

        public PriceInfoService(IExcelReaderService excelReaderService, ReflectionHelper reflectionHelper)
        {
            _excelReaderService = excelReaderService;
            _reflectionHelper = reflectionHelper;
        }

        public List<PriceInfoDto> GetAllPriceInfo()
        {
            var excelData = _excelReaderService.GetExcelDataBySheetName(SheetConstants.PriceInfo);

            var priceInfoList = new List<PriceInfoDto>();

            foreach (var data in excelData)
            {
                priceInfoList.Add(new PriceInfoDto
                {
                    Date = DateTime.Parse(data.FirstOrDefault(x => x.Key == _reflectionHelper.GetDescriptionByProperty<PriceInfoDto>("Date")).Value.Replace("2025-05", "2024-07")),
                    PTF = decimal.Parse(data.FirstOrDefault(x => x.Key == _reflectionHelper.GetDescriptionByProperty<PriceInfoDto>("PTF")).Value)
                });
            }

            return priceInfoList;
        }
    }
}
