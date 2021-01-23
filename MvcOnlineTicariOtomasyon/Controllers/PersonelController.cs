using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel

        Context c = new Context();

        public ActionResult Index()
        {
            var personel = c.Personels.ToList();
            return View(personel);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DEPARTMANAD,
                                               Value = x.DEPARTMANID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count>0)
            {
                string dosyadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/images/" + dosyadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PERSONELGORSEL = "/images/" + dosyadi + uzanti;
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DEPARTMANAD,
                                               Value = x.DEPARTMANID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var personel = c.Personels.Find(id);
            return View("PersonelGetir", personel);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/images/" + dosyadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PERSONELGORSEL = "/images/" + dosyadi + uzanti;
            }
            var personel = c.Personels.Find(p.PERSONELID);
            personel.PERSONELAD = p.PERSONELAD;
            personel.PERSONELSOYAD = p.PERSONELSOYAD;
            personel.PERSONELGORSEL = p.PERSONELGORSEL;
            personel.DEPARTMANID = p.DEPARTMANID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
    }
}