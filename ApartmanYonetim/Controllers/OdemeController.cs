using Microsoft.AspNetCore.Mvc;
using System.Data;
using Entities.Models;
using System.Linq;
using ApartmanYonetim.Models;
using System.Security.Claims;

namespace ApartmanApp.Controllers
{
    public class OdemeController : Controller
    {
        private readonly KayitContext _context;

        public OdemeController(KayitContext context)
        {
            _context = context;
        }

        // GET: /Odeme/Takip
        public IActionResult Takip()
        {
            var odemeler = _context.Odemes.ToList();
            return View(odemeler);
        }
        public IActionResult Odemeler()
{
    // Giriş yapan kullanıcının ID'sini al
    int kullaniciId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

    // Sadece o kullanıcıya ait ödemeleri getir
    var odemeler = _context.Odemes
        .Where(o => o.KullaniciId == kullaniciId)
        .ToList();

    return View(odemeler);
}

        // GET: /Odeme/Duzenle
        public IActionResult Duzenle()
        {
            return View();
        }

        // POST: /Odeme/Duzenle
        [HttpPost]
        public IActionResult Duzenle(Odeme model)
        {
            if (ModelState.IsValid)
            {
                _context.Odemes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Takip");
            }
            return View(model);
        }

        // GET: /Odeme/Edit/{id}
        public IActionResult Edit(int id)
        {
            var odeme = _context.Odemes.Find(id);
            if (odeme == null)
            {
                return NotFound();
            }
            return View(odeme);
        }

        // POST: /Odeme/Edit/{id}
        [HttpPost]
        public IActionResult Edit(Odeme model)
        {
            if (ModelState.IsValid)
            {
                _context.Odemes.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Takip");
            }
            return View(model);
        }

        // GET: /Odeme/Delete/{id}
        public IActionResult Delete(int id)
        {
            var odeme = _context.Odemes.Find(id);
            if (odeme == null)
            {
                return NotFound();
            }
            return View(odeme);
        }

        // POST: /Odeme/DeleteConfirmed/{id}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var odeme = _context.Odemes.Find(id);
            if (odeme != null)
            {
                _context.Odemes.Remove(odeme);
                _context.SaveChanges();
            }
            return RedirectToAction("Takip");
        }

    }
}
