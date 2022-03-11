using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Kontrol
{
    public class BusinessLogicLayer
    {
        Entities.OtobusBilgileri otobus;
        Kisiler kisi;
        OtobusveMusteri ovm;
        Database data;
        public BusinessLogicLayer()
        {
            data = new Database();
            otobus = new OtobusBilgileri();
            kisi = new Kisiler();
            ovm = new OtobusveMusteri();
        }

        public int guzergahYaz(List<string> guzergah)
        {
            int bayrak;
            if (guzergah.Count <= 1)
            {
                bayrak = -100;
            }
            else
            {
                otobus.OtobusID = Guid.NewGuid();
                otobus.guzergah = guzergah;
                otobus.firmaAdi = "gg";
                otobus.koltukSayisi = 40;
                otobus.SeferVakti = DateTime.Now;
                otobus.TutulanKoltuk = new HashSet<string>();
                bayrak=data.guzergahYaz(otobus);
            }
                return bayrak;
        }

        public int musteriEkle(string koltukNumarasi,string baslangic, string bitis,string ad,string soyad,string tc,object ot)
        {
            if (!string.IsNullOrEmpty(baslangic) && !string.IsNullOrEmpty(bitis) && !string.IsNullOrEmpty(ad) &&
                !string.IsNullOrEmpty(soyad) && !string.IsNullOrEmpty(tc) && ot != null)
            {
                OtobusBilgileri musteriveOtobus = (OtobusBilgileri)ot;
                musteriveOtobus.TutulanKoltuk.Add(koltukNumarasi);

                Kisiler kisi = new Kisiler();
                kisi.kullaniciId = Guid.NewGuid();
                kisi.ad = ad;
                kisi.soyad = soyad;
                kisi.tc = tc;
                kisi.yaptigiSeferSayisi = 1;
                kisi.gidecegiYer = bitis;
                kisi.bulunduguYer = baslangic;
                kisi.OtobusId = musteriveOtobus.OtobusID;
                kisi.tutulanKoltuk = koltukNumarasi;
                int bayrak = data.musteriEkle(musteriveOtobus, kisi);
                return bayrak;
            }
            else
                return -100;
            
        }

        public List<OtobusBilgileri> otobusBilgisiAl()
        {
            List<OtobusBilgileri> otobus = data.otobusListesiAl();
            return otobus;
        }

        public List<OtobusBilgileri> guzergahGetir(string basla,string bit)
        {
            List<OtobusBilgileri> otobusler = data.otobusListesiAl();
            List<OtobusBilgileri> gelenGuzergah = otobusler.FindAll(i => i.guzergah.Contains(basla) && i.guzergah.Contains(bit));
            List<OtobusBilgileri> gidenGuzergah = new List<OtobusBilgileri>();
            foreach (OtobusBilgileri item1 in gelenGuzergah)
            {
                int a =item1.guzergah.FindIndex(i => i == basla);
                int b = item1.guzergah.FindIndex(i => i == bit);
                if (a < b)
                    gidenGuzergah.Add(item1);
                
            }   
            return gidenGuzergah;
        }

        public List<string> koltukGetir(Guid otobusId,string basla,string bit)
        {
            List<Kisiler> k =data.koltukGetir(otobusId);
            List<string> koltuklar = new List<string>();
            foreach (Kisiler item in k)
            {
                if(item.bulunduguYer==basla&&item.gidecegiYer==bit)
                {
                    koltuklar.Add(item.tutulanKoltuk);
                }
            }
            return koltuklar; 
        }

    }
}
