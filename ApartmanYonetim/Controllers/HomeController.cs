using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ApartmanYonetim.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Entities.Models;

namespace ApartmanYonetim.Controllers;

public class HomeController : Controller
{
    [HttpPost]
[HttpPost]
public async Task<IActionResult> Login(string username, string password)
{
    var kullanici = _context.Kullanicis
        .FirstOrDefault(k => k.KullaniciAd == username && k.Sifre == password);

    if (kullanici == null)
    {
        ViewBag.Hata = "Geçersiz kullanıcı adı veya şifre";
        return View("Index");
    }

    // Kimlik bilgileri
    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, kullanici.KullaniciAd ?? ""),
        new Claim(ClaimTypes.NameIdentifier, (kullanici.KullaniciId ?? 0).ToString())
    };

    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    var principal = new ClaimsPrincipal(identity);

    // Tarayıcıya kimliği tanıt
    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

    int kullaniciId = kullanici.KullaniciId ?? 0;

    if (kullaniciId == 1)
        return RedirectToAction("Yonetici");
    else if (kullaniciId >= 2 && kullaniciId <= 10)
        return RedirectToAction("ApartmanSakini");
    else if (kullaniciId == 11)
        return RedirectToAction("Calisan");
    else
        return View("Index"); // Tanımsız kullanıcı tipi
}

private readonly KayitContext _context;

public HomeController(ILogger<HomeController> logger, KayitContext context)
{
    _logger = logger;
    _context = context;
}

    private readonly ILogger<HomeController> _logger;


    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Yonetici()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


        // Çalışanlar için yönlendirme
        
    public IActionResult Calisan()
    {
        return View("Calisan");
    }

    public IActionResult ApartmanSakini()
    {
        return View("ApartmanSakini");
    }
}