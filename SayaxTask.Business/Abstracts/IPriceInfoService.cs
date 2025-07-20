using SayaxTask.Business.Dtos;

namespace SayaxTask.Business.Abstracts
{
    public interface IPriceInfoService
    {
        List<PriceInfoDto> GetAllPriceInfo();
    }
}
