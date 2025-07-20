using SayaxTask.Business.Abstracts;
using SayaxTask.Business.Dtos;

namespace SayaxTask.Business.Services
{
    public class S3CalculationService : ICalculationService
    {
        public decimal CalculateBTV(decimal totalEnergyCost, int btvPercentage)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateDistributionCost(string tariffName)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateEnergyCost(MeterInfoDto meterInfo)
        {
            throw new NotImplementedException();
        }
    }
}
