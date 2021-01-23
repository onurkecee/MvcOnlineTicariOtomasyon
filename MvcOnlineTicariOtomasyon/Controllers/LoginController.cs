using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Register()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Register(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult CariGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariGiris(Cariler p)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CARIMAIL == p.CARIMAIL && x.CARISIFRE == p.CARISIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CARIMAIL, false);
                Session["CARIMAIL"] = bilgiler.CARIMAIL.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KULLANICIADI == p.KULLANICIADI && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICIADI, false);
                Session["KULLANICIADI"] = bilgiler.KULLANICIADI.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}