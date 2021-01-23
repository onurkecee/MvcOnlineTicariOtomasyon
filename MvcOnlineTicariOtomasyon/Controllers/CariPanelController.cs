using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CARIMAIL"];
            var degerler = c.Mesajs.Where(x => x.ALICI == mail).ToList();
            ViewBag.m = mail;

            var mailid = c.Carilers.Where(x => x.CARIMAIL == mail).Select(y => y.CARIID).FirstOrDefault();
            ViewBag.mid = mailid;

            var toplamsatis = c.SatisHarekets.Where(x => x.CARIID == mailid).Count();
            ViewBag.toplamsatis = toplamsatis;

            var toplamtutar = c.SatisHarekets.Where(x => x.CARIID == mailid).Sum(y => y.TOPLAMTUTAR);
            ViewBag.toplamtutar = toplamtutar;

            var toplamurunsayisi = c.SatisHarekets.Where(x => x.CARIID == mailid).Sum(y => y.ADET);
            ViewBag.toplamurunsayisi = toplamurunsayisi;

            var adsoyad = c.Carilers.Where(x => x.CARIMAIL == mail).Select(y => y.CARIAD + " " + y.CARISOYAD).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var mailadres = c.Carilers.Where(x => x.CARIMAIL == mail).Select(y => y.CARIMAIL).FirstOrDefault();
            ViewBag.mailadres = mailadres;
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CARIMAIL"];
            var id = c.Carilers.Where(x => x.CARIMAIL == mail.ToString()).Select(y => y.CARIID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CARIID == id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CARIMAIL"];
            var mesajlar = c.Mesajs.Where(x => x.ALICI == mail).OrderByDescending(x => x.MESAJID).ToList();

            var gelenmesajsayisi = c.Mesajs.Count(x => x.ALICI == mail).ToString();
            ViewBag.d1 = gelenmesajsayisi;

            var gidenmesajsayisi = c.Mesajs.Count(x => x.GONDERICI == mail).ToString();
            ViewBag.d2 = gidenmesajsayisi;
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CARIMAIL"];
            var mesajlar = c.Mesajs.Where(x => x.GONDERICI == mail).OrderByDescending(x => x.MESAJID).ToList();

            var gelenmesajsayisi = c.Mesajs.Count(x => x.ALICI == mail).ToString();
            ViewBag.d1 = gelenmesajsayisi;

            var gidenmesajsayisi = c.Mesajs.Count(x => x.GONDERICI == mail).ToString();
            ViewBag.d2 = gidenmesajsayisi;
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var mesajdetay = c.Mesajs.Where(x => x.MESAJID == id).ToList();


            var mail = (string)Session["CARIMAIL"];
            var gelenmesajsayisi = c.Mesajs.Count(x => x.ALICI == mail).ToString();
            ViewBag.d1 = gelenmesajsayisi;

            var gidenmesajsayisi = c.Mesajs.Count(x => x.GONDERICI == mail).ToString();
            ViewBag.d2 = gidenmesajsayisi;
            return View(mesajdetay);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CARIMAIL"];
            var gelenmesajsayisi = c.Mesajs.Count(x => x.ALICI == mail).ToString();
            ViewBag.d1 = gelenmesajsayisi;

            var gidenmesajsayisi = c.Mesajs.Count(x => x.GONDERICI == mail).ToString();
            ViewBag.d2 = gidenmesajsayisi;
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesaj m)
        {
            var mail = (string)Session["CARIMAIL"];
            m.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.GONDERICI = mail;
            c.Mesajs.Add(m);
            c.SaveChanges();
            return View();
        }

        public ActionResult KargoTakip(string p)
        {
            var kargodetay = from x in c.KargoDetays select x;
            kargodetay = kargodetay.Where(y => y.TAKIPKODU.Contains(p));
            return View(kargodetay.ToList());
        }

        public ActionResult CariKargoTakip(string id)
        {
            var kargo = c.KargoTakips.Where(x => x.TAKIPNO == id).ToList();
            return View(kargo);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult BilgileriGuncelle()
        {
            var mail = (string)Session["CARIMAIL"];
            var id = c.Carilers.Where(x => x.CARIMAIL == mail).Select(y => y.CARIID).FirstOrDefault();
            var caribul = c.Carilers.Find(id);
            return PartialView("BilgileriGuncelle", caribul);
        }

        public PartialViewResult Duyurular()
        {
            var duyurular = c.Mesajs.Where(x => x.GONDERICI == "admin").ToList();
            return PartialView(duyurular);
        }

        public ActionResult CariBilgiGuncelle(Cariler p)
        {
            var cari = c.Carilers.Find(p.CARIID);
            cari.CARIAD = p.CARIAD;
            cari.CARIMAIL = p.CARIMAIL;
            cari.CARISEHIR = p.CARISEHIR;
            cari.CARISIFRE = p.CARISIFRE;
            cari.CARISOYAD = p.CARISOYAD;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}