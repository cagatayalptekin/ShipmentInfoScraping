using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapingFormProject
{
    public class Shipment
    {
        public int Id { get; set; }
        public string TakipNumarası { get; set; }
        public string GondericiAd { get; set; }
        public string GondericiFirma { get; set; }
        public string AliciAd { get; set; }
        public string AliciFirma { get; set; }
        public string AliciSehir { get; set; }
        public string AlinisTarihi { get; set; }
        public string GonderiTarihi { get; set; }
        public string AliciUlke { get; set; }
        public string GondericiAdres { get; set; }
        public string KargoFirmasi { get; set; }
    }
}
