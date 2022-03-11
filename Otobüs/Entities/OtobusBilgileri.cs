using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OtobusBilgileri
    {
        public string firmaAdi { get; set; }
        public int koltukSayisi { get; set; }
        public List<string> guzergah { get; set; }
        public DateTime SeferVakti { get; set; }
        public HashSet<string> TutulanKoltuk { get; set; }
        public Guid OtobusID { get; set; }

        public override string ToString()
        {
            string[] sehir = guzergah.ToArray();
            int index = sehir.Length;
            
            return $"{sehir[0]} ve {sehir[index-1]} {SeferVakti} otobüsü";
        }

        
    }
}
