using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Kullanici 
{
    public String? KullaniciAd { get; set; }
    public int? KullaniciId { get; set; }
    public String? Sifre { get; set; }
    public String? Telefon { get; set; } 
    public String? Mail { get; set; } 
}

 public class Odeme
    {
        public int OdemeId {get; set;}
        public int KullaniciId {get; set;}
        public String? KullaniciAd {get; set;}
        public int OdenecekTutar {get; set;}
        public bool OdemeBilgisi {get; set;}

    }


  public class Duyuru 
    { 
        public int DuyuruId {get; set;}
        public String? Baslik {get; set;}
        public String? Icerik {get; set;}
    }

    public class Calisan
    {

        public int CalisanId { get; set; }
        public String? CalisanAdi { get; set; }
        public String? Sifre { get; set; }
        public String? Gorev { get; set; }
        public String? Telefon { get; set; } 
        public String? Mail { get; set; }  
    }

    public class Gorev
    {
        public int GorevId { get; set; }
        public String? GorevAd { get; set; }
        public bool Durum { get; set; }

    }