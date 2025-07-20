using SayaxTask.Business.Dtos;

namespace SayaxTask.Business.Abstracts
{
    public interface IExcelReaderService
    {
        MeterInfoDto GetMeterInfo(string meterName);
        List<MeterConsuptionDto> GetMeterConsuptions(string sheetName);
        List<PriceInfoDto> GetAllPriceInfo();
    }
}
