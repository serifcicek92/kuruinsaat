using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kuruinsaat.Controllers
{
    [Authorize]
    public class YonetimController : Controller
    {
        // GET: Yonetim
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProjeEkle() {

            return View();
        }

        public ActionResult ProjeList() {
            return View();
        }
    }
}