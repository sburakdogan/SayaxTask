using SayaxTask.Business.Abstracts;
using SayaxTask.Business.Constants;
using SayaxTask.Business.Dtos;
using SayaxTask.Business.Helper;

namespace SayaxTask.Business.Services
{
    public class MeterService : IMeterService
    {
        private readonly ExcelReaderHelper _excelReaderHelper;
        private readonly ReflectionHelper _reflectionHelper;

        public MeterService(ReflectionHelper reflectionHelper, ExcelReaderHelper excelReaderHelper)
        {
            _reflectionHelper = reflectionHelper;
            _excelReaderHelper = excelReaderHelper;
        }

        public MeterInfoDto GetMeterInfo(string meterName)
        {
            var excelData = _excelReaderHelper.ReadFile(SheetConstants.MeterInfo);

            var meterInfoList = new List<MeterInfoDto>();

            foreach (var data in excelData)
            {
                meterInfoList.Add(new MeterInfoDto
                {
                    MeterName = data.FirstOrDefault(x => x.Key == _reflectionHelper.GetDescriptionByProperty<MeterInfoDto>("MeterName")).Value,
                    Method = data.FirstOrDefault(x => x.Key == _reflectionHelper.GetDescriptionByProperty<MeterInfoDto>("Method")).Value,
                    CommissionOrDiscount = data.FirstOrDefault(x => x.Key == _reflectionHelper.GetDescriptionByProperty<MeterInfoDto>("CommissionOrDiscount")).Value,
                    BTV = decimal.Parse(data.FirstOrDefault(x => x.Key == _reflectionHelper.GetDescriptionByProperty<MeterInfoDto>("BTV")).Value),
                    KDV = decimal.Parse(data.FirstOrDefault(x => x.Key == _reflectionHelper.GetDescriptionByProperty<MeterInfoDto>("KDV")).Value),
                    TariffName = data.FirstOrDefault(x => x.Key == _reflectionHelper.GetDescriptionByProperty<MeterInfoDto>("TariffName")).Value,
                    Municipality = data.FirstOrDefault(x => x.Key == _reflectionHelper.GetDescriptionByProperty<MeterInfoDto>("Municipality")).Value,
                });
            }

            return meterInfoList.FirstOrDefault(x => x.MeterName == meterName);
        }

        public List<MeterConsuptionDto> GetMeterConsuptions(string sheetName)
        {
            var excelData = _excelReaderHelper.ReadFile(sheetName);

            var meterConsuptionList = new List<MeterConsuptionDto>();

            foreach (var data in excelData)
            {
                meterConsuptionList.Add(new MeterConsuptionDto
                {
                    MeterName = data.FirstOrDefault(x => x.Key == _reflectionHelper.GetDescriptionByProperty<MeterConsuptionDto>("MeterName")).Value,
                    Date = data.FirstOrDefault(x => x.Key == _reflectionHelper.GetDescriptionByProperty<MeterConsuptionDto>("Date")).Value,
                    Time = int.Parse(data.FirstOrDefault(x => x.Key == _reflectionHelper.GetDescriptionByProperty<MeterConsuptionDto>("Time")).Value),
                    Cost = decimal.Parse(data.FirstOrDefault(x => x.Key == _reflectionHelper.GetDescriptionByProperty<MeterConsuptionDto>("Cost")).Value),
                });
            }

            return meterConsuptionList;
        }
    }
}
