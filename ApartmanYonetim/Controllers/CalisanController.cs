using Microsoft.AspNetCore.Mvc;
using ApartmanYonetim.Models;
using Entities.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

public class CalisanController : Controller
{
    private readonly KayitContext _context;

    public CalisanController(KayitContext context)
    {
        _context = context;
    }

    // Ana Panel
    public IActionResult Calisan()
    {
        var calisanAdi = User.Identity?.Name;
        ViewBag.CalisanAdi = calisanAdi;
        return View();
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

    // Görevleri Listele
    public IActionResult Gorevler()
    {
        var gorevler = _context.Gorevs.ToList();
        return View(gorevler);
    }

    // Görev Durumu Değiştir
    [HttpPost]
    public IActionResult GorevDurumDegistir(int id)
    {
        var gorev = _context.Gorevs.FirstOrDefault(g => g.GorevId == id);
        if (gorev != null)
        {
            gorev.Durum = !gorev.Durum;
            _context.SaveChanges();
        }
        return RedirectToAction("Gorevler");
    }

    // Duyuruları Listele
    public IActionResult Duyurular()
    {
        var duyurular = _context.Duyurus.ToList();
        return View(duyurular);
    }

}
