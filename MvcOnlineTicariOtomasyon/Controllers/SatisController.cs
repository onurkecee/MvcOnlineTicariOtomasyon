using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var satis = c.SatisHarekets.ToList();
            return View(satis);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Urunlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.URUNAD,
                                               Value = x.URUNID.ToString()
                                           }).ToList();

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

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket p)
        {
            p.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Urunlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.URUNAD,
                                               Value = x.URUNID.ToString()
                                           }).ToList();

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

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            var satis = c.SatisHarekets.Find(id);
            return View("SatisGetir", satis);
        }

        public ActionResult SatisGuncelle(SatisHareket p)
        {
            var satis = c.SatisHarekets.Find(p.SATISID);
            satis.CARIID = p.CARIID;
            satis.ADET = p.ADET;
            satis.FIYAT = p.FIYAT;
            satis.PERSONELID = p.PERSONELID;
            satis.TARIH = p.TARIH;
            satis.TOPLAMTUTAR = p.TOPLAMTUTAR;
            satis.URUNID = p.URUNID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var satisdetay = c.SatisHarekets.Where(x => x.SATISID == id).ToList();
            return View(satisdetay);
        }
    }
}