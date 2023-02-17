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
    public class ProjelerController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Projeler
        public ActionResult Index()
        {
            List<Proje> DevamEdenProjeler = db.Projeler.ToList();
            List<Dosya> Dosyalar = db.Dosyalar.ToList();
            ViewBag.Dosyalar = Dosyalar;
            ViewBag.DevamEdenProjeler = DevamEdenProjeler;
            List<Resim> resimler = db.Resimler.ToList();
            return View(resimler);
        }

        public ActionResult DevamEden()
        {
            List<Proje> DevamEdenProjeler = db.Projeler.Where(x => x.Tamamlandimi == false).ToList();
            List<Dosya> Dosyalar = db.Dosyalar.ToList();
            ViewBag.Dosyalar = Dosyalar;
            ViewBag.DevamEdenProjeler = DevamEdenProjeler;
            List<Resim> resimler = db.Resimler.ToList();
            return View(resimler);
        }

        public ActionResult Tamamlanan()
        {
            List<Proje> TamamlananProjeler = db.Projeler.Where(x => x.Tamamlandimi == true).ToList();
            List<Dosya> Dosyalar = db.Dosyalar.ToList();
            ViewBag.Dosyalar = Dosyalar;
            ViewBag.TamamlananProjeler = TamamlananProjeler;
            List<Resim> resimler = db.Resimler.ToList();
            return View(resimler);
        }

     
        public ActionResult Proje(int id)
        {
            List<Proje> Proje = db.Projeler.Where(x => x.Id == id).ToList();
            List<Dosya> Dosyalar = db.Dosyalar.Where(x=>x.ElementTypeNo==1 && x.ElementTypeId==id).ToList();
            ViewBag.Dosyalar = Dosyalar;
            ViewBag.Proje = Proje;
            List<Resim> resimler = db.Resimler.Where(x=>x.ElementTypeNo == 1 && x.ElementTypeId == id ).ToList();
            return View("ProjeDetay",resimler);
        }

        public ActionResult Panorama(int id)
        {
            Dosya panorama = db.Dosyalar.Where(x => x.Id == id).FirstOrDefault();
            return View(panorama);
        }

    }
}