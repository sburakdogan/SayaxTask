using SayaxTask.Business.Abstracts;
using SayaxTask.Business.Services;

namespace SayaxTask.Api.Factory
{
    public class CalculationServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CalculationServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public BaseCalculationService CreateCalculationService(string meterName)
        {
            return meterName switch
            {
                "S1" => _serviceProvider.GetRequiredService<S1CalculationService>(),
                "S2" => _serviceProvider.GetRequiredService<S2CalculationService>(),
                "S3" => _serviceProvider.GetRequiredService<S3CalculationService>(),
                _ => throw new ArgumentException("Geçersiz sayaç adı.")
            };
        }
    }
}
