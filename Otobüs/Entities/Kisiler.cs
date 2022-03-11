using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kisiler
    {
        public Guid kullaniciId { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string tc { get; set; }
        public string gidecegiYer { get; set; }
        public string bulunduguYer { get; set; }
        public int yaptigiSeferSayisi { get; set; }
        public Guid OtobusId { get; set; }
        public string tutulanKoltuk { get; set; }


        public override string ToString()
        {
            return $"{ad} {soyad}";
        }
    }
}
