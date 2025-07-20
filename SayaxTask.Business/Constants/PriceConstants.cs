namespace SayaxTask.Business.Constants
{
    public class PriceConstants
    {
        public const int YEK = 300;
        public const int CommercialEnergyTariff = 3000;
        public const int IndustricalEnergyTariff = 2800;
        public const int CommercialDistributionTariff = 600;
        public const int IndustricalDistribution = 500;

        public static int GetEnergyTariffPriceByName(string tariffName)
        {
            return tariffName switch
            {
                "Sanayi" => IndustricalEnergyTariff,
                "TicaretHane" => CommercialEnergyTariff,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}