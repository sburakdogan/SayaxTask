using System.ComponentModel;

namespace SayaxTask.Business.Dtos
{
    public class PriceInfoDto
    {
        [Description("Takvim_TarihSaat")]
        public DateTime Date { get; set; }

        [Description("PTF (TL/MWh)")]
        public decimal PTF { get; set; }
    }
}
