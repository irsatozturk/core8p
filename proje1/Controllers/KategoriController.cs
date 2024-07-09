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

        //**************//
        //KAYDETME ALANI//
        //**************//
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

        //***************//
        //DÜZENLEME ALANI//
        //***************//
        public IActionResult kategoriDuzenle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Kategori? dbDatasi = _veritabani.Kategoriler.Find(id);
            /*Kategori? dbDatasi = _veritabani.Kategoriler.Find(x => x.Id == id);*/

            if (dbDatasi == null)
            {
                return NotFound();
            }
            return View(dbDatasi);
        }
        [HttpPost]
        public IActionResult kategoriDuzenle(Kategori gelenData)
        {
            if (ModelState.IsValid)
            {
                _veritabani.Kategoriler.Update(gelenData);
                _veritabani.SaveChanges();
                return RedirectToAction("Index", "Kategori");
            }
            return View(gelenData);
        }

        //***************//
        //SİLME ALANI//
        //***************//
        public IActionResult kategoriSil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Kategori? dbDatasi = _veritabani.Kategoriler.Find(id);

            if (dbDatasi == null)
            {
                return NotFound();
            }
            return View(dbDatasi);
        }
        [HttpPost]
        public IActionResult kategoriSil(Kategori gelenData)
        {
            _veritabani.Kategoriler.Remove(gelenData);
            _veritabani.SaveChanges();
            return RedirectToAction("Index", "Kategori");
        }
    }
}
