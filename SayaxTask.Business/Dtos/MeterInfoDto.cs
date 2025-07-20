using System.ComponentModel;

namespace SayaxTask.Business.Dtos
{
    public class MeterInfoDto
    {
        [Description("Sayac")]
        public string MeterName { get; set; }

        [Description("Satış Yönetimi")]
        public string Method { get; set; }

        [Description("Komisyon / İndirim")]
        public string CommissionOrPercentage { get; set; }

        [Description("BTV Oranı")]
        public decimal BTV { get; set; }

        [Description("KDV Oranı")]
        public decimal KDV { get; set; }

        [Description("Tarife Adı")]
        public string TariffName { get; set; }

        [Description("Belediye")]
        public string Municipality { get; set; }

        public decimal GetCommissionOrPercentage()
        {
            if (CommissionOrPercentage.Contains('%'))
                return int.Parse(CommissionOrPercentage.Replace("%", ""));

            else if (CommissionOrPercentage.Contains("TL"))
                return int.Parse(CommissionOrPercentage.Replace("TL", ""));

            else
                return 0;
        }
    }
}
