using Microsoft.AspNetCore.Mvc;
using ApartmanYonetim.Models;
using System.Diagnostics;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ApartmanYonetim.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly KayitContext _context;

        public KullaniciController(KayitContext context)
        {
            _context = context;
        }
         [Authorize]
        public IActionResult Profil()
        {
            var kullaniciAdi = User.Identity?.Name;
            if (string.IsNullOrEmpty(kullaniciAdi))
            {
                return RedirectToAction("Login", "Home");
            }

            var kullanici = _context.Kullanicis.FirstOrDefault(k => k.KullaniciAd == kullaniciAdi);
            if (kullanici == null)
            {
                return View("Error");
            }

            return View(kullanici); // Model olarak gönder
        }
        public IActionResult Index()
        {
            var model = _context.Kullanicis.ToList();
            return View(model);
        }
        public IActionResult Get(int id)
        {
            Kullanici kullanici = _context.Kullanicis.First(k => k.KullaniciId.Equals(id));
            return View(kullanici);
        }

        [HttpPost]
        public IActionResult KullaniciSil(int id)
        {
            var kullanici = _context.Kullanicis.FirstOrDefault(k => k.KullaniciId == id);
            if (kullanici != null)
            {
                _context.Kullanicis.Remove(kullanici);
                _context.SaveChanges();
            }
            return RedirectToAction("Index"); // Listeleme action'ına yönlendir
        }

        // GET: Formu göster
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GorevEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GorevEkle(Gorev gorev)
        {
            if (ModelState.IsValid)
            {
                _context.Gorevs.Add(gorev);
                _context.SaveChanges();
                return RedirectToAction("Gorevler");
            }

            return View(gorev);
        }

        public IActionResult Gorevler()
        {
            var gorevler = _context.Gorevs.ToList();
            return View(gorevler); // Views/Kullanici/Gorevler.cshtml olmalı
        }

        [HttpPost]
        public IActionResult GorevSil(int id)
        {
            var gorev = _context.Gorevs.FirstOrDefault(g => g.GorevId == id);
            if (gorev != null)
            {
                _context.Gorevs.Remove(gorev);
                _context.SaveChanges();
            }
            return RedirectToAction("Gorevler");
        }

        // POST: Yeni kullanıcıyı ekle
        [HttpPost]
        public IActionResult Ekle(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                _context.Kullanicis.Add(kullanici);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kullanici); // Hata varsa formu tekrar göster
        }

             [HttpPost]
            public IActionResult Duzenle(Kullanici model)
            {
                var kullanici = _context.Kullanicis.FirstOrDefault(k => k.KullaniciId == model.KullaniciId);
                if (kullanici == null)
                    return NotFound();

                // Alanları güncelle
                kullanici.KullaniciAd = model.KullaniciAd;
                kullanici.Sifre = model.Sifre;
                kullanici.Mail = model.Mail;
                kullanici.Telefon = model.Telefon;

                _context.SaveChanges();

                return RedirectToAction("Index"); // Kullanıcı listesine dön
            }
            [HttpGet]
                public IActionResult Duzenle(int id)
                {
                    var kullanici = _context.Kullanicis.FirstOrDefault(k => k.KullaniciId == id);
                    if (kullanici == null)
                        return NotFound();

                    return View(kullanici);
                }


            
    }
}