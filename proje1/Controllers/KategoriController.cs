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
        public IActionResult kategoriOlustur(Kategori postData)
        {
            if (postData.Name == postData.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("name", "Kategori adı sıra numarası ile aynı olamaz");
            }
            if (ModelState.IsValid)
            {
                _veritabani.Kategoriler.Add(postData);
                _veritabani.SaveChanges();
                TempData["basarili"] = "Kategori Kayıt İşlemi Başarılı";
                return RedirectToAction("Index", "Kategori");
            }
            return View(postData);
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
        public IActionResult kategoriDuzenle(Kategori postData)
        {
            if (ModelState.IsValid)
            {
                _veritabani.Kategoriler.Update(postData);
                _veritabani.SaveChanges();
                return RedirectToAction("Index", "Kategori");
            }
            return View(postData);
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
        [HttpPost, ActionName("kategoriSil")]
        //Yukardaki "kategoriSil" ve aşağıdaki "kategoriSil" aynı veri tipi "int" takpi ediyor,
        //Hangisinin devreye gireceğinde karışıklık olacağı için alttakinin sonuna "_x" ekledim
        public IActionResult kategoriSil_x(int? id)
        {
            Kategori? dbDatasi = _veritabani.Kategoriler.Find(id);
            if (dbDatasi == null)
            {
                return NotFound();
            }
            _veritabani.Kategoriler.Remove(dbDatasi);
            _veritabani.SaveChanges();
            return RedirectToAction("Index", "Kategori");
        }
    }
}
