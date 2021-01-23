using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Urunlers select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.URUNAD.Contains(p));
            }
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KATEGORIAD,
                                               Value = x.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urunler p)
        {
            if (ModelState.IsValid)
            {
                c.Urunlers.Add(p);
                p.DURUM = true;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urunler = c.Urunlers.Find(id);
            urunler.DURUM = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KATEGORIAD,
                                               Value = x.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urundeger = c.Urunlers.Find(id);
            return View("UrunGetir", urundeger);
        }

        public ActionResult UrunGuncelle(Urunler p)
        {
            var urun = c.Urunlers.Find(p.URUNID);
            urun.ALISFIYAT = p.ALISFIYAT;
            urun.DURUM = p.DURUM;
            urun.KATEGORIID = p.KATEGORIID;
            urun.MARKA = p.MARKA;
            urun.SATISFIYAT = p.SATISFIYAT;
            urun.SATISHAREKETS = p.SATISHAREKETS;
            urun.STOK = p.STOK;
            urun.URUNAD = p.URUNAD;
            urun.URUNGORSEL = p.URUNGORSEL;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var urunlistesi = c.Urunlers.ToList();
            return View(urunlistesi);
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            //List<SelectListItem> deger1 = (from x in c.Urunlers.ToList()
            //                               select new SelectListItem
            //                               {
            //                                   Text = x.URUNAD,
            //                                   Value = x.URUNID.ToString()
            //                               }).ToList();

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CARIAD + " " + x.CARISOYAD,
                                               Value = x.CARIID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PERSONELAD + " " + x.PERSONELSOYAD,
                                               Value = x.PERSONELID.ToString()
                                           }).ToList();


            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            var deger = c.Urunlers.Find(id);

            ViewBag.d = deger.URUNID;
            ViewBag.SatisFiyat = deger.SATISFIYAT;


            ViewBag.d1 = deger.URUNAD;
            ViewBag.UrunAd = deger.URUNAD;

            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index", "Satis");
        }
    }
}