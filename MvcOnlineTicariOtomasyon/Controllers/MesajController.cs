using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class MesajController : Controller
    {
        Context c = new Context();
        // GET: Mesaj
        public ActionResult Index()
        {
            return View();
        }
    }
}