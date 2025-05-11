using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using ApartmanYonetim.Models;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

[Authorize] // Tüm action'lar için geçerli
public class SakinController : Controller
{
    private readonly KayitContext _context;

    public SakinController(KayitContext context)
    {
        _context = context;
    }

    // Kullanıcının profil bilgileri
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
public async Task<IActionResult> Logout()
{
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return RedirectToAction("Index");
}


   [Authorize]
public IActionResult Odemeler()
{
    var kullaniciAdi = User.Identity?.Name;

    if (string.IsNullOrEmpty(kullaniciAdi))
    {
        return RedirectToAction("Index", "Home");
    }

    var odemeler = _context.Odemes
        .Where(o => o.KullaniciAd == kullaniciAdi)
        .ToList();

    return View(odemeler);
}


    // Duyuruları listele
    public IActionResult Duyurular()
    {
        var duyurular = _context.Duyurus.ToList();
        return View(duyurular);
    }

}
