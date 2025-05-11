using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using ApartmanYonetim.Models;

public class DuyuruController : Controller
{
    private readonly KayitContext _context;

    public DuyuruController(KayitContext context)
    {
        _context = context;
    }

    // GET: /Duyuru
    public IActionResult Index()
    {
        var duyurular = _context.Duyurus.ToList();
        return View(duyurular);
    }
    public IActionResult IndexA()
    {
        var duyurular = _context.Duyurus.ToList();
        return View(duyurular);
    }
    public IActionResult IndexC()
    {
        var duyurular = _context.Duyurus.ToList();
        return View(duyurular);
    }
    // GET: /Duyuru/Ekle
    public IActionResult Ekle()
    {
        return View();
    }


    // POST: /Duyuru/Ekle
    [HttpPost]
    public IActionResult Ekle(Duyuru duyuru)
    {
        if (ModelState.IsValid)
        {
            _context.Duyurus.Add(duyuru);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(duyuru);
    }

    [HttpPost]
    public IActionResult Sil(int id)
    {
        var duyuru = _context.Duyurus.Find(id);
        if (duyuru != null)
        {
            _context.Duyurus.Remove(duyuru);
            _context.SaveChanges();
        }
        return RedirectToAction("Index"); // Duyuru listesine geri dön
    }

}
