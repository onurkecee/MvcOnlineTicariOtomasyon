using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        // GET: Departman

        Context c = new Context();
        public ActionResult Index()
        {
            var departman = c.Departmans.Where(x => x.DURUM == true).ToList(); ;
            return View(departman);
        }

        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman p)
        {
            c.Departmans.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var departman = c.Departmans.Find(id);
            departman.DURUM = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = c.Departmans.Find(id);
            return View("DepartmanGetir", departman);
        }

        public ActionResult DepartmanGuncelle(Departman p)
        {
            var departman = c.Departmans.Find(p.DEPARTMANID);
            departman.DEPARTMANAD = p.DEPARTMANAD;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var departman = c.Personels.Where(x => x.DEPARTMANID == id).ToList();
            var d = c.Departmans.Where(x => x.DEPARTMANID == id).Select(y => y.DEPARTMANAD).FirstOrDefault();
            ViewBag.d = d;
            return View(departman);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var personelsatis = c.SatisHarekets.Where(x => x.PERSONELID == id).ToList();
            var d = c.Personels.Where(x => x.PERSONELID == id).Select(y => y.PERSONELAD + " " + y.PERSONELSOYAD).FirstOrDefault();
            ViewBag.d = d;
            return View(personelsatis);
        }
    }
}