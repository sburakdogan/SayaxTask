using System.ComponentModel;

namespace SayaxTask.Business.Dtos
{
    public class MeterConsuptionDto
    {
        [Description("Sayac_No")]
        public string MeterName { get; set; }

        [Description("Tarih")]
        public string Date { get; set; }

        [Description("Saat")]
        public int Time { get; set; }

        [Description("Tüketim (MWh)")]
        public decimal Cost { get; set; }

        public DateTime CombinedDateTime()
        {
            var date = DateTime.Parse(Date);

            if (Time == 24)
                return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);

            return new DateTime(date.Year, date.Month, date.Day, Time, 0, 0, 0);
        }
    }
}
