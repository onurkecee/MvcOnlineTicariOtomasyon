using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grafik()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Beyaz Eşya", "Telefon", "Küçük Ev Aletleri", "Bilgisayar", "Mobilya" }, yValues: new[] { 50, 60, 100, 785, 15 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Grafik2()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Urunlers.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.URUNAD));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.STOK));
            var grafik = new Chart(width: 500, height: 500).AddTitle("Stoklar").AddSeries(chartType: "Column", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult GoogleGrafik()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }

        public List<Google> UrunListesi()
        {
            List<Google> snf = new List<Google>();
            snf.Add(new Google()
            {
                URUNAD = "Bilgisayar",
                STOKSAYISI = 120
            });
            snf.Add(new Google()
            {
                URUNAD = "Beyaz Eşya",
                STOKSAYISI = 240
            });
            snf.Add(new Google()
            {
                URUNAD = "Küçük Ev Aletleri",
                STOKSAYISI = 440
            });
            snf.Add(new Google()
            {
                URUNAD = "Mobilya",
                STOKSAYISI = 44
            });
            snf.Add(new Google()
            {
                URUNAD = "Telefon",
                STOKSAYISI = 750
            });
            return snf;
        }

        public ActionResult GoogleGrafik2()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<Google2> UrunListesi2()
        {
            List<Google2> snf = new List<Google2>();
            using (var context = new Context())
            {
                snf = c.Urunlers.Select(x => new Google2
                {
                    URUN = x.URUNAD,
                    STOK = x.STOK
                }).ToList();
            }
        return snf;
        }

        public ActionResult GoogleGrafik3()
        {
            return View();
        }

        public ActionResult GoogleGrafik4()
        {
            return View();
        }
    }
}