using kuruinsaat.Entity;
using kuruinsaat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kuruinsaat.Controllers
{
    public class AnasayfaController : Controller
    {
        private DataContext db = new DataContext();
        public ActionResult Index()
        {
            List<Resim> resimler =  db.Resimler.ToList();
            return View(resimler);
        }
    }
}