using Entities.Models;
using ApartmanYonetim.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartmanYonetim.Models
{
    //veri tabanı gibi işlem görücek
    public class KayitContext : DbContext //RepositoryContext
    {

        public DbSet<Kullanici> Kullanicis {get; set;}
        public DbSet<Duyuru> Duyurus {get; set;}
        public DbSet<Odeme> Odemes {get; set;}
        public DbSet<Calisan> Calisans {get; set;}
        public DbSet<Gorev> Gorevs {get; set;}
        
        public KayitContext(DbContextOptions<KayitContext> options) : base(options)
        {
            
        }

        public KayitContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Kullanici>()
            .HasData(
                new Kullanici() {KullaniciId=1,KullaniciAd="Fatma Açıkgöz",Sifre="1234", Telefon="0555 444 33 22", Mail="fatma@gmail.com"},
                new Kullanici() {KullaniciId = 2,KullaniciAd = "Sinem Kaya" ,Sifre="1234",Telefon="0523 414 33 22", Mail="sinem@gmail.com"},
                new Kullanici() {KullaniciId=3,KullaniciAd="Ali Tulup",Sifre="1234",Telefon="0509 314 45 45", Mail="ali@gmail.com"},
                new Kullanici() {KullaniciId=4,KullaniciAd="Erkut Demirci",Sifre="1234",Telefon="0595 416 57 19", Mail="erkut@gmail.com"},
                new Kullanici() {KullaniciId=5,KullaniciAd="Umut Kaya",Sifre="1234",Telefon="0556 364 11 00", Mail="umut@gmail.com"},
                new Kullanici() {KullaniciId=6,KullaniciAd="Mehmet Dinçer",Sifre="1234",Telefon="0567 444 33 22", Mail="mehmet@gmail.com"},
                new Kullanici() {KullaniciId=7,KullaniciAd="Sueda İnce",Sifre="1234",Telefon="0544 567 17 17", Mail="sueda@gmail.com"},
                new Kullanici() {KullaniciId=8,KullaniciAd="Sudenaz Gündüz",Sifre="1234",Telefon="0543 419 45 57", Mail="sudenaz@gmail.com"},
                new Kullanici() {KullaniciId=9,KullaniciAd="Selin Poyraz",Sifre="1234",Telefon="0557 654 75 45", Mail="selin@gmail.com"},
                new Kullanici() {KullaniciId=10,KullaniciAd="Esra Kasap",Sifre="1234",Telefon="0585 325 93 22", Mail="esra@gmail.com"},
                new Kullanici() {KullaniciId=11,KullaniciAd="Ahmet Yılmaz",Sifre="1234",Telefon="0575 486 33 12", Mail="ahmet@gmail.com"}

            );

            modelBuilder.Entity<Calisan>()
            .HasData(
            new Calisan() { CalisanId = 11, CalisanAdi = "Ahmet Yılmaz", Sifre = "1234", Gorev = "Çöpleri Topla",Telefon="0575 486 33 12", Mail="ahmet@gmail.com" }
            ); 
            modelBuilder.Entity<Gorev>()
            .HasData(
            new Gorev() { GorevId = 1, GorevAd = "Çöpleri Topla", Durum = true  }
            );
        }
    }
}