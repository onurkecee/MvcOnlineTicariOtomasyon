using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using PagedList;
using PagedList.Mvc;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa, 10);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = c.Kategoris.Find(id);
            c.Kategoris.Remove(kategori);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var kategori = c.Kategoris.Find(k.KATEGORIID);
            kategori.KATEGORIAD = k.KATEGORIAD;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Cascading()
        {
            Cascading cs = new Cascading();
            cs.Kategoriler = new SelectList(c.Kategoris, "KATEGORIID", "KATEGORIAD");
            cs.Urunler = new SelectList(c.Urunlers, "URUNID", "URUNAD");
            return View(cs);
        }

        public JsonResult Cascading2(int p)
        {
            var urunlistesi = (from x in c.Urunlers
                               join y in c.Kategoris on x.KATEGORI.KATEGORIID equals y.KATEGORIID
                               where x.KATEGORI.KATEGORIID == p
                               select new
                               {
                                   Text = x.URUNAD,
                                   Value = x.URUNID.ToString()
                               }).ToList();
            return Json(urunlistesi, JsonRequestBehavior.AllowGet); 
        }
    }
}