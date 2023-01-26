using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kuruinsaat.Controllers
{
    public class YonetimController : Controller
    {
        // GET: Yonetim
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}