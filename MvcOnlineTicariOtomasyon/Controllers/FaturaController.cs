using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura

        Context c = new Context();
        public ActionResult Index()
        {
            var faturalar = c.Faturalars.ToList();
            return View(faturalar);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Faturalar p)
        {
            var fatura = c.Faturalars.Find(p.FATURAID);
            fatura.FATURASERİNO = p.FATURASERİNO;
            fatura.FATURASIRANO = p.FATURASIRANO;
            fatura.TARIH = p.TARIH;
            fatura.VERGIDAIRESI = p.VERGIDAIRESI;
            fatura.SAAT = p.SAAT;
            fatura.TESLIMALAN = p.TESLIMALAN;
            fatura.TESLIMEDEN = p.TESLIMEDEN;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var faturadetay = c.FaturaKalems.Where(x => x.FATURAID == id).ToList();
            return View(faturadetay);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dinamik()
        {
            DinamikFatura cs = new DinamikFatura();
            cs.deger1 = c.Faturalars.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs);
        }

        public ActionResult FaturaKaydet(string FATURASERİNO, string FATURASIRANO, DateTime TARIH, string VERGIDAIRESI, string SAAT, string TESLIMEDEN, string TESLİMALAN, string TOPLAM, FaturaKalem[] kalem)
        {
            Faturalar f = new Faturalar();
            f.FATURASERİNO = FATURASERİNO;
            f.FATURASIRANO = FATURASIRANO;
            f.TARIH = TARIH;
            f.VERGIDAIRESI = VERGIDAIRESI;
            f.SAAT = SAAT;
            f.TESLIMEDEN = TESLIMEDEN;
            f.TESLIMALAN = TESLİMALAN;
            f.TOPLAM = decimal.Parse(TOPLAM);
            c.Faturalars.Add(f);
            foreach (var x in kalem)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.ACIKLAMA = x.ACIKLAMA;
                fk.BIRIMFIYAT = x.BIRIMFIYAT;
                fk.FATURAID = x.FATURAKALEMID;
                fk.MIKTAR = x.MIKTAR;
                fk.TUTAR = x.TUTAR;
                c.FaturaKalems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}