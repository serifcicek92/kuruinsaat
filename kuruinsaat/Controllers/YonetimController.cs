using kuruinsaat.Entity;
using kuruinsaat.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kuruinsaat.Controllers
{
    [Authorize]
    public class YonetimController : Controller
    {
        DataContext db = new DataContext();
        // GET: Yonetim

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProjeEkle()
        {
            List<Resim> resimler = new List<Resim>();
            if (System.Web.HttpContext.Current.Session["RESIMUUID"] != null)
            {
                string resimUUID = System.Web.HttpContext.Current.Session["RESIMUUID"].ToString();
                List<Resim> resimleruuid = db.Resimler.Where(x => x.UUID == resimUUID && x.Aktif == 1).ToList();
                resimler.AddRange(resimleruuid);
            }
            ViewBag.resimler = resimler;

            List<Dosya> dosyalarPanorama = new List<Dosya>();
            if (System.Web.HttpContext.Current.Session["FILEUUID"] != null)
            {
                string fileUUID = System.Web.HttpContext.Current.Session["FILEUUID"].ToString();
                List<Dosya> dosyalarUUid = db.Dosyalar.Where(x => x.UUID == fileUUID && x.Type == 1 && x.Aktif == 1).ToList();
                dosyalarPanorama.AddRange(dosyalarUUid);
            }

            ViewBag.dosyalarPanorama = dosyalarPanorama;

            List<Dosya> dosyalarPdf = new List<Dosya>();
            if (System.Web.HttpContext.Current.Session["FILEUUID"] != null)
            {
                string fileUUID = System.Web.HttpContext.Current.Session["FILEUUID"].ToString();
                List<Dosya> dosyalarPdfUUid = db.Dosyalar.Where(x => x.UUID == fileUUID && x.Type == 2 && x.Aktif == 1).ToList();
                dosyalarPdf.AddRange(dosyalarPdfUUid);
            }
            ViewBag.dosyalarPdf = dosyalarPdf;

            List<Dosya> dosyalarVideo = new List<Dosya>();
            if (System.Web.HttpContext.Current.Session["FILEUUID"] != null)
            {
                string fileUUID = System.Web.HttpContext.Current.Session["FILEUUID"].ToString();
                List<Dosya> dosyalarVideoUUid = db.Dosyalar.Where(x => x.UUID == fileUUID && x.Type == 3 && x.Aktif==1).ToList();
                dosyalarVideo.AddRange(dosyalarVideoUUid);
            }
            ViewBag.dosyalarVideo = dosyalarVideo;

            return View();
        }


        // GET: About/Edit/5
        public ActionResult Edit(int id)
        {
            Proje proje = db.Projeler.Where(x => x.Id == id).FirstOrDefault();
            List<Resim> resimler = db.Resimler.Where(x => x.ElementTypeNo == 1 && x.ElementTypeId == id && x.Aktif == 1).ToList();
            if (System.Web.HttpContext.Current.Session["RESIMUUID"] != null)
            {
                List<Resim> resimleruuid = db.Resimler.Where(x => x.UUID == System.Web.HttpContext.Current.Session["RESIMUUID"].ToString() && x.Aktif == 1).ToList();
                resimler.AddRange(resimleruuid);
            }
            ViewBag.resimler = resimler;

            List<Dosya> dosyalarPanorama = db.Dosyalar.Where(x => x.ElementTypeNo == 1 && x.ElementTypeId == id && x.Type==1).ToList();
            if (System.Web.HttpContext.Current.Session["FILEUUID"] != null)
            {
                List<Dosya> dosyalarUUid = db.Dosyalar.Where(x => x.UUID == System.Web.HttpContext.Current.Session["FILEUUID"].ToString() && x.Type == 1).ToList();
                dosyalarPanorama.AddRange(dosyalarUUid);
            }

            ViewBag.dosyalarPanorama = dosyalarPanorama;

            List<Dosya> dosyalarPdf = db.Dosyalar.Where(x => x.ElementTypeNo == 1 && x.ElementTypeId == id && x.Type == 2).ToList();
            if (System.Web.HttpContext.Current.Session["FILEUUID"] != null)
            {
                List<Dosya> dosyalarPdfUUid = db.Dosyalar.Where(x => x.UUID == System.Web.HttpContext.Current.Session["FILEUUID"].ToString() && x.Type == 2).ToList();
                dosyalarPdf.AddRange(dosyalarPdfUUid);
            }
            ViewBag.dosyalarPdf = dosyalarPdf;

            List<Dosya> dosyalarVideo = db.Dosyalar.Where(x => x.ElementTypeNo == 1 && x.ElementTypeId == id && x.Type == 3).ToList();
            if (System.Web.HttpContext.Current.Session["FILEUUID"] != null)
            {
                List<Dosya> dosyalarVideoUUid = db.Dosyalar.Where(x => x.UUID == System.Web.HttpContext.Current.Session["FILEUUID"].ToString() && x.Type == 3).ToList();
                dosyalarVideo.AddRange(dosyalarVideoUUid);
            }
            ViewBag.dosyalarVideo = dosyalarVideo;

            return View("ProjeEkle", proje);
        }

        [HttpPost]
        public ActionResult ProjeEkle(Proje proje)
        {
            try
            {
                if (proje.Id == null || proje.Id.Equals(0))
                {
                    Kullanici k = (Kullanici)System.Web.HttpContext.Current.Session["Kullanici"];
                    proje.EkleyenId = k.Id;
                    proje.EklemeZamani = DateTime.Now;
                    proje.GuncelleyenId = k.Id;
                    proje.Guncellemezamani = DateTime.Now;
                    proje.TeslimTarihi = DateTime.ParseExact(Request["TeslimTarihi"].ToString(), "MM/dd/yyyy h:mm tt", CultureInfo.InvariantCulture);
                    proje.Aktif = 1;
                    db.Projeler.Add(proje);
                    db.SaveChanges();

                }
                else
                {
                    var prj = db.Projeler.Where(x => x.Id == proje.Id).FirstOrDefault();
                    prj = proje;
                    db.SaveChanges();
                }
                if (System.Web.HttpContext.Current.Session["RESIMUUID"] != null)
                {
                    ResimUpdateElementId(1, proje.Id, System.Web.HttpContext.Current.Session["RESIMUUID"].ToString());//create edilen id alınacak uuid den resimlere atanacak
                    System.Web.HttpContext.Current.Session.Remove("RESIMUUID");
                }
                if (System.Web.HttpContext.Current.Session["FILEUUID"] != null)
                {
                    DosyaUpdateElementId(1, proje.Id, System.Web.HttpContext.Current.Session["FILEUUID"].ToString());//create edilen id alınacak uuid den resimlere atanacak
                    System.Web.HttpContext.Current.Session.Remove("FILEUUID");
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new HttpException(e.Message);
            }
        }


        [HttpPost]
        public ActionResult ProjeDuzenle(int id)
        {
            try
            {
                Proje proje = db.Projeler.Where(x => x.Id == id).FirstOrDefault();
                Kullanici k = (Kullanici)System.Web.HttpContext.Current.Session["Kullanici"];
                proje.Guncellemezamani = DateTime.Now;
                proje.GuncelleyenId = k.Id;
                proje.Adi = Request["Adi"] == null ? proje.Adi : Request["Adi"].ToString();
                proje.Adres = Request["Adres"] == null ? proje.Adres : Request["Adres"].ToString();
                proje.ArsaAlani = Request["ArsaAlani"] == null ? proje.ArsaAlani : Int32.Parse(Request["ArsaAlani"].ToString());
                proje.KullanilabilirAlan = Request["KullanilabilirAlan"] == null ? proje.KullanilabilirAlan : Int32.Parse(Request["KullanilabilirAlan"].ToString());
                proje.ToplamKonutSayisi = Request["ToplamKonutSayisi"] == null ? proje.ToplamKonutSayisi : Int32.Parse(Request["ToplamKonutSayisi"].ToString());
                proje.BlokAdedi = Request["BlokAdedi"] == null ? proje.BlokAdedi : Int32.Parse(Request["BlokAdedi"].ToString());
                proje.TeslimTarihi = Request["TeslimTarihi"] == null ? proje.TeslimTarihi : DateTime.ParseExact(Request["TeslimTarihi"].ToString(), "MM/dd/yyyy h:mm tt", CultureInfo.InvariantCulture);
                proje.Sira = Request["Sira"] == null ? proje.Sira : Int32.Parse(Request["Sira"]);
                proje.Tamamlandimi = Request["Tamamlandimi"] == null ? proje.Tamamlandimi : Boolean.Parse(Request["Tamamlandimi"]);
                db.SaveChanges();
                if (System.Web.HttpContext.Current.Session["RESIMUUID"] != null)
                {
                    ResimUpdateElementId(1, proje.Id, System.Web.HttpContext.Current.Session["RESIMUUID"].ToString());//create edilen id alınacak uuid den resimlere atanacak
                    System.Web.HttpContext.Current.Session.Remove("RESIMUUID");

                }
                if (System.Web.HttpContext.Current.Session["FILEUUID"] != null)
                {
                    ResimUpdateElementId(1, proje.Id, System.Web.HttpContext.Current.Session["FILEUUID"].ToString());
                    System.Web.HttpContext.Current.Session.Remove("FILEUUID");
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new HttpException(e.Message);
            }
        }

        public ActionResult ProjeList()
        {
            List<Proje> projeler = db.Projeler.Where(x=>x.Aktif==1).ToList();
            return View(projeler);
        }

        [HttpPost]
        public JsonResult ResimYukle(Resim resim)
        {
            List<Resim> resimlist = new List<Resim>();
            if (System.Web.HttpContext.Current.Session["RESIMUUID"] == null)
                System.Web.HttpContext.Current.Session.Add("RESIMUUID", Guid.NewGuid());

            int imageCount = Request.Files.Count;
            string UUID = System.Web.HttpContext.Current.Session["RESIMUUID"].ToString();
            for (int i = 0; i < imageCount; i++)
            {
                try
                {
                    Kullanici k = (Kullanici)System.Web.HttpContext.Current.Session["Kullanici"];
                    Resim resimYukle = new Resim();
                    //Save Image
                    string path = Path.Combine(Server.MapPath("~/Assets/Images/Uploads"), Path.GetFileName(Request.Files[i].FileName));
                    Request.Files[i].SaveAs(path);

                    //Save Thump
                    string path2 = Path.Combine(Server.MapPath("~/Assets/Images/Uploads"), "thump_" + Path.GetFileName(Request.Files[i].FileName));
                    Image img = ScaleImage(Image.FromStream(Request.Files[i].InputStream), 75, 75);
                    img.Save(path2);

                    resimYukle.ResimYolu = Path.GetFileName(Request.Files[i].FileName);
                    resimYukle.ThumpResimYolu = "thump_" + Path.GetFileName(Request.Files[i].FileName);
                    resimYukle.Title = Path.GetFileName(Request.Files[i].FileName);
                    resimYukle.ElementTypeId = 1;
                    resimYukle.UUID = UUID;
                    resimYukle.EkleyenId = k.Id;
                    resimYukle.EklemeZamani = DateTime.Now;
                    resimYukle.GuncelleyenId = k.Id;
                    resimYukle.Guncellemezamani = DateTime.Now;
                    resimYukle.Aktif = 1;
                    resimlist.Add(resimYukle);

                }
                catch (Exception e)
                {

                    throw new HttpException(e.Message);
                }
            }
            foreach (var item in resimlist)
            {
                db.Resimler.Add(item);
            }
            db.SaveChanges();
            return Json(resimlist, JsonRequestBehavior.AllowGet);
            //return Json(db.Resimler.Where(x=>x.UUID==UUID).ToList(), JsonRequestBehavior.AllowGet);


        }


        // GET: Security/Edit/5
        public void ResimUpdateElementId(int elementTypNo, int ElementId, string guuid)
        {
            try
            {
                var resimList = db.Resimler.Where(x => x.UUID == guuid).ToList();
                foreach (var item in resimList)
                {
                    item.ElementTypeId = ElementId;
                    item.ElementTypeNo = elementTypNo;
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new HttpException(e.Message);
            }

        }

        public ActionResult Delete(int id)
        {

            string httpref = HttpContext.Request.Headers["Referer"];
            Proje p = db.Projeler.Where(q => q.Id == id).FirstOrDefault();
            p.Aktif = 0;
            db.SaveChanges();
            return Redirect(httpref);
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        [HttpPost]
        public JsonResult DosyaYukle()
        {
            try
            {
                string type = Request["type"].ToString();
                if (Request.Files != null && Request.Files.Count>0)
                {
                    Kullanici k = (Kullanici)System.Web.HttpContext.Current.Session["Kullanici"];

                    if (System.Web.HttpContext.Current.Session["FILEUUID"] == null)
                        System.Web.HttpContext.Current.Session.Add("FILEUUID", Guid.NewGuid());

                    string UUID = System.Web.HttpContext.Current.Session["FILEUUID"].ToString();
                    Dosya dosya = new Dosya();

                    //Save Image
                    string path = Path.Combine(Server.MapPath("~/Assets/Uploads"), Path.GetFileName(Request.Files[0].FileName));
                    Request.Files[0].SaveAs(path);

                   
                    dosya.DosyaYolu = Path.GetFileName(Request.Files[0].FileName);
                    dosya.Title = Path.GetFileName(Request.Files[0].FileName);
                    dosya.ElementTypeId = 1;
                    dosya.Type = Int32.Parse(type);
                    dosya.UUID = UUID;
                    dosya.EkleyenId = k.Id;
                    dosya.EklemeZamani = DateTime.Now;
                    dosya.GuncelleyenId = k.Id;
                    dosya.Guncellemezamani = DateTime.Now;
                    dosya.Aktif = 1;

                    db.Dosyalar.Add(dosya);
                    db.SaveChanges();

                    return Json(dosya, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return null;
        }
        public void DosyaUpdateElementId(int elementTypNo, int ElementId, string guuid)
        {
            try
            {
                var resimList = db.Dosyalar.Where(x => x.UUID == guuid).ToList();
                foreach (var item in resimList)
                {
                    item.ElementTypeId = ElementId;
                    item.ElementTypeNo = elementTypNo;
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new HttpException(e.Message);
            }

        }


        public ActionResult AnasayfadaGoster(int id)
        {
            Kullanici k = (Kullanici)System.Web.HttpContext.Current.Session["Kullanici"];
            Resim res = db.Resimler.Where(x => x.Id == id).FirstOrDefault();
            List<Resim> resimlerList = db.Resimler.Where(x => x.UUID == res.UUID).ToList();

            foreach (Resim item in resimlerList)
            {
                item.AnasayfadaGoster = 0;
            }
            res.AnasayfadaGoster = 1;
            res.GuncelleyenId = k.Id;
            res.Guncellemezamani = DateTime.Now;
            db.SaveChanges();
            string httpref = HttpContext.Request.Headers["Referer"];
            return Redirect(httpref);
        }
        public ActionResult KapakYap(int id)
        {
            Kullanici k = (Kullanici)System.Web.HttpContext.Current.Session["Kullanici"];
            Resim res = db.Resimler.Where(x => x.Id == id).FirstOrDefault();

            List<Resim> resimlerList = db.Resimler.Where(x => x.UUID == res.UUID).ToList();

            foreach (Resim item in resimlerList)
            {
                item.KapakYap = 0;
            }
            res.KapakYap = 1;
            res.GuncelleyenId = k.Id;
            res.Guncellemezamani = DateTime.Now;
            db.SaveChanges();

            string httpref = HttpContext.Request.Headers["Referer"];
            return Redirect(httpref);

        }
        public ActionResult ResimSil(int id)
        {
            Kullanici k = (Kullanici)System.Web.HttpContext.Current.Session["Kullanici"];
            Resim res = db.Resimler.Where(x => x.Id == id).FirstOrDefault();

            res.Aktif = 0;
            res.GuncelleyenId = k.Id;
            res.Guncellemezamani = DateTime.Now;
            
            db.SaveChanges();
            string httpref = HttpContext.Request.Headers["Referer"];
            return Redirect(httpref);
        }
    }
}