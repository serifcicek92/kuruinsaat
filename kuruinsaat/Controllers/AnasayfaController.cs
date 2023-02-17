using kuruinsaat.Entity;
using kuruinsaat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kuruinsaat.Controllers
{
    [AllowAnonymous]
    public class AnasayfaController : Controller
    {
        private DataContext db = new DataContext();
        public ActionResult Index()
        {
            List<Proje> TamamlananProjeler = db.Projeler.Where(x=>x.Tamamlandimi==true).ToList();
            List<Proje> DevamEdenProjeler = db.Projeler.Where(x=>x.Tamamlandimi==false).ToList();
            List<Dosya> Dosyalar = db.Dosyalar.ToList();
            ViewBag.Dosyalar = Dosyalar;
            ViewBag.TamamlananProjeler = TamamlananProjeler;
            ViewBag.DevamEdenProjeler = DevamEdenProjeler;
            List<Resim> resimler =  db.Resimler.ToList();
            return View(resimler);
        }
    }
}