using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {

        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            DateTime bugun = DateTime.Now.Date;

            var deger1 = c.Carilers.Count().ToString(); //Toplam Cari Sayısı
            var deger2 = c.Urunlers.Count().ToString(); //Toplam Ürün Sayısı
            var deger3 = c.Personels.Count().ToString(); //Toplam Personel Sayısı
            var deger4 = c.Kategoris.Count().ToString(); //Toplam Kategori Sayısı
            var deger5 = c.Urunlers.Sum(x => x.STOK).ToString(); //Toplam Stok Sayısı
            var deger6 = (from x in c.Urunlers select x.MARKA).Distinct().Count().ToString(); //Ürünler tablosunun içinden markayı seç ve benzersiz olarak göster
            var deger7 = c.Urunlers.Count(x => x.STOK <= 20).ToString(); //Stokta kaç adet 20'den fazla ürün var
            var deger8 = (from x in c.Urunlers orderby x.SATISFIYAT descending select x.URUNAD).FirstOrDefault(); //urunler tablosundan satışfiyatı alıp en yüksek sıralayıp ilk değeri al
            var deger9 = (from x in c.Urunlers orderby x.SATISFIYAT ascending select x.URUNAD).FirstOrDefault();  //urunler tablosundan satışfiyatı alıp en düşük sıralayıp ilk değeri al
            //var deger10 = (from x in c.Urunlers orderby x.STOK descending select x.URUNAD).FirstOrDefault();
            var deger10 = c.Urunlers.GroupBy(x => x.MARKA).OrderByDescending(y => y.Count()).Select(y => y.Key).FirstOrDefault();
            var deger11 = c.Urunlers.Count(x => x.URUNAD == "Buzdolabı").ToString();
            var deger12 = c.Urunlers.Count(x => x.URUNAD == "Laptop").ToString();
            var deger13 = c.Urunlers.Where(u => u.URUNID == (c.SatisHarekets.GroupBy(x => x.URUNID).OrderByDescending(y => y.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.URUNAD).FirstOrDefault(); //En çok satılan marka
            var deger14 = c.SatisHarekets.Sum(x => x.TOPLAMTUTAR).ToString(); //Kasadaki toplam tutar
            var deger15 = c.SatisHarekets.Count(x => x.TARIH == bugun).ToString(); //Bugün yapılan satışlar
            var deger16 = c.SatisHarekets.Where(x => x.TARIH == bugun).Sum(y => (decimal?)y.TOPLAMTUTAR).ToString(); //Bugün yapılan satışların toplam tutarı
            if (deger15 == "0")
            {
                deger16 = "0";
            }
           

            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            ViewBag.d3 = deger3;
            ViewBag.d4 = deger4;
            ViewBag.d5 = deger5;
            ViewBag.d6 = deger6;
            ViewBag.d7 = deger7;
            ViewBag.d8 = deger8;
            ViewBag.d9 = deger9;
            ViewBag.d10 = deger10;
            ViewBag.d11 = deger11;
            ViewBag.d12 = deger12;
            ViewBag.d13 = deger13;
            ViewBag.d14 = deger14;
            ViewBag.d15 = deger15;
            ViewBag.d16 = deger16;
            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.CARISEHIR into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());

        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.DEPARTMAN.DEPARTMANAD into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu = c.Carilers.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial3()
        {
            var sorgu = c.Urunlers.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Urunlers
                        group x by x.MARKA into g
                        select new SinifGrup3
                        {
                            Marka = g.Key,
                            Sayi = g.Count()
                        };
            return PartialView(sorgu.ToList());
        }

    }
}