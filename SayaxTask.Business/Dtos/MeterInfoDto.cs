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
        public decimal CommissionOrDiscount { get; set; }

        [Description("BTV Oranı")]
        public decimal BTV { get; set; }

        [Description("KDV Oranı")]
        public decimal KDV { get; set; }

        [Description("Tarife Adı")]
        public string TariffName { get; set; }

        [Description("Belediye")]
        public string Municipality { get; set; }
    }
}
