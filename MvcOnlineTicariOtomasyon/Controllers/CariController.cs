using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var cari = c.Carilers.Where(x => x.DURUM == true).ToList();
            return View(cari);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cariler p)
        {
            p.DURUM = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cari = c.Carilers.Find(id);
            cari.DURUM = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);
        }

        public ActionResult CariGuncelle(Cariler p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Carilers.Find(p.CARIID);
            cari.CARIAD = p.CARIAD;
            cari.CARISOYAD = p.CARISOYAD;
            cari.CARISEHIR = p.CARISEHIR;
            cari.CARIMAIL = p.CARIMAIL;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariDetay(int id)
        {
            var cari = c.SatisHarekets.Where(x => x.CARIID == id).ToList();
            var d = c.Carilers.Where(x => x.CARIID == id).Select(y => y.CARIAD + " " + y.CARISOYAD).FirstOrDefault();
            ViewBag.d = d;
            return View(cari);
        }
    }
}