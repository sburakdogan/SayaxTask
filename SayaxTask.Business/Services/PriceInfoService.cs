using SayaxTask.Business.Abstracts;
using SayaxTask.Business.Constants;
using SayaxTask.Business.Dtos;
using SayaxTask.Business.Helper;

namespace SayaxTask.Business.Services
{
    public class PriceInfoService : IPriceInfoService
    {
        private readonly ExcelReaderHelper _excelReaderHelper;
        private readonly ReflectionHelper _reflectionHelper;

        public PriceInfoService(ReflectionHelper reflectionHelper, ExcelReaderHelper excelReaderHelper)
        {
            _reflectionHelper = reflectionHelper;
            _excelReaderHelper = excelReaderHelper;
        }

        public List<PriceInfoDto> GetAllPriceInfo()
        {
            var excelData = _excelReaderHelper.ReadFile(SheetConstants.PriceInfo);

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
