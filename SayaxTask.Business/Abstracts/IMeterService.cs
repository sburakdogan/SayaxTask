using SayaxTask.Business.Dtos;

namespace SayaxTask.Business.Abstracts
{
    public interface IMeterService
    {
        MeterInfoDto GetMeterInfo(string meterName);
        List<MeterConsuptionDto> GetMeterConsuptions(string sheetName);
    }
}
