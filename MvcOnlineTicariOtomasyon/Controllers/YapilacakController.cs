using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        Context c = new Context();
        // GET: Yapilacak
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            var deger2 = c.Urunlers.Count().ToString();
            var deger3 = c.Kategoris.Count().ToString();
            var deger4 = (from x in c.Carilers select x.CARISEHIR).Distinct().Count().ToString();
           
            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            ViewBag.d3 = deger3;
            ViewBag.d4 = deger4;

            var yapilacaklar = c.Yapilacaks.ToList();
            return View(yapilacaklar);
        }
    }
}