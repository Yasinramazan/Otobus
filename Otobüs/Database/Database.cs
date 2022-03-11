using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;

namespace Kontrol
{
    public class Database
    {
        List<OtobusBilgileri> otobusBilgileri;
        List<Kisiler> Kisiler;
        SqlConnection con;
        SqlCommand cmd;
        public Database()
        {
            Kontrol();
            otobusBilgileri = new List<OtobusBilgileri>();
            Kisiler = new List<Kisiler>();
            con = new SqlConnection("Database=.;initial catalog = Otobus,user Id=sa,password=1");

        }

        private void Kontrol()
        {
            if (!Directory.Exists(@"C:\\Otobus Programı"))
                Directory.CreateDirectory(@"C:\\Otobus Programı");

            if(!File.Exists(@"C:\\Otobus Programı\\Otobüs Bilgileri.json"))
                using(File.Create(@"C:\\Otobus Programı\\Otobüs Bilgileri.json")) { }
            if(!File.Exists(@"C:\\Otobus Programı\\Kişiler.json"))
                using(File.Create(@"C:\\Otobus Programı\\Kişiler.json")) { }
        }

        public void OtobusBilgisiAl()
        {
            string otobus = File.ReadAllText(@"C:\\Otobus Programı\\Otobüs Bilgileri.json");
            if(Newtonsoft.Json.JsonConvert.DeserializeObject<List<OtobusBilgileri>>(otobus)!=null)
                otobusBilgileri = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OtobusBilgileri>>(otobus);
        }

        public int guzergahYaz(OtobusBilgileri o)
        {
            
            OtobusBilgisiAl();
            otobusBilgileri.Add(o);
           
            int bayrak = tryCatch.trycatch(() =>
            {
                string otobusYaz = Newtonsoft.Json.JsonConvert.SerializeObject(otobusBilgileri);
                File.WriteAllText(@"C:\\Otobus Programı\\Otobüs Bilgileri.json", otobusYaz);
            });
            return bayrak;   
        }

        public void otobusYaz()
        {
            string yaz = Newtonsoft.Json.JsonConvert.SerializeObject(otobusBilgileri);
            File.WriteAllText(@"C:\\Otobus Programı\\Otobüs Bilgileri.json", yaz);
        }

        public void musteriYaz()
        {
            string yaz = Newtonsoft.Json.JsonConvert.SerializeObject(Kisiler);
            File.WriteAllText(@"C:\\Otobus Programı\\Kişiler.json",yaz);
        }

        public void musteriAl()
        {
            string musteri = File.ReadAllText(@"C:\\Otobus Programı\\Kişiler.json");
            if (Newtonsoft.Json.JsonConvert.DeserializeObject<List<Kisiler>>(musteri) != null)
                Kisiler = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Kisiler>>(musteri);
        }

        public List<OtobusBilgileri> otobusListesiAl()
        {
            OtobusBilgisiAl();
            return otobusBilgileri;
        }

        public int musteriEkle(OtobusBilgileri o,Kisiler kisi)
        {
            OtobusBilgisiAl();
            musteriAl();
            int bayrak = tryCatch.trycatch(() => 
            {
                int a = otobusBilgileri.FindIndex(i => i.OtobusID == o.OtobusID);
                otobusBilgileri[a] = o;
                Kisiler.Add(kisi);
            }); 
            musteriYaz();
            otobusYaz();
            
            return bayrak;
        }

        public List<Kisiler> koltukGetir(Guid otobusId)
        {
            musteriAl();
            List<Kisiler> k = Kisiler.FindAll(i => i.OtobusId == otobusId);
            return k;
        }

        
        
    }
}

