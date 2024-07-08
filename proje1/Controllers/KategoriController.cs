using Microsoft.AspNetCore.Mvc;
using proje1.Data;
using proje1.Models;

namespace proje1.Controllers
{
    public class KategoriController : Controller
    {
        private readonly ApplicationDbContext _veritabani;

        public KategoriController(ApplicationDbContext veritabani)
        {
            _veritabani = veritabani;
        }

        public IActionResult Index()
        {
            List<Kategori> kategoriListesi = _veritabani.Kategoriler.ToList();
            return View(kategoriListesi);
        }

        public IActionResult kategoriOlustur()
        {
            return View();
        }
        [HttpPost]
        public IActionResult kategoriOlustur(Kategori gelenData)
        {
            if (gelenData.Name == gelenData.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("name", "Kategori adı sıra numarası ile aynı olamaz");
            }
            if (ModelState.IsValid)
            {
                _veritabani.Kategoriler.Add(gelenData);
                _veritabani.SaveChanges();
                return RedirectToAction("Index", "Kategori");
            }
            return View(gelenData);
        }
    }
}
