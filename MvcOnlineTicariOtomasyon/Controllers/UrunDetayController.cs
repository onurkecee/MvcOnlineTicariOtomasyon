﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            //var degerler = c.Urunlers.Where(x => x.URUNID == 1).ToList();
            Class1 cs = new Class1();
            cs.Deger1 = c.Urunlers.Where(x => x.URUNID == 1).ToList();
            cs.Deger2 = c.Detays.Where(y => y.DETAYID == 1).ToList();
            return View(cs);
        }
    }
}