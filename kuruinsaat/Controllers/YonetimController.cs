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


            return View();
        }


        // GET: About/Edit/5
        public ActionResult Edit(int id)
        {
            Proje proje = db.Projeler.Where(x => x.Id == id).FirstOrDefault();
            List<Resim> resimler = db.Resimler.Where(x => x.ElementTypeNo == 1 && x.ElementTypeId == id).ToList();
            ViewBag.resimler = resimler;
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
                db.Projeler.Add(proje);
                db.SaveChanges();
                if (System.Web.HttpContext.Current.Session["RESIMUUID"] != null)
                {
                    ResimUpdateElementId(1, proje.Id, System.Web.HttpContext.Current.Session["RESIMUUID"].ToString());//create edilen id alınacak uuid den resimlere atanacak
                    System.Web.HttpContext.Current.Session.Remove("RESIMUUID");

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
            List<Proje> projeler = db.Projeler.ToList();
            return View(projeler);
        }

        [HttpPost]
        public JsonResult ResimYukle(Resim resim)
        {
            List<Resim> resimlist = new List<Resim>();
            if (System.Web.HttpContext.Current.Session["RESIMUUID"] == null)
                System.Web.HttpContext.Current.Session.Add("RESIMUUID", Guid.NewGuid());

            int imageCount = Request.Files.Count;
            for (int i = 0; i < imageCount; i++)
            {
                try
                {
                    Kullanici k = (Kullanici)System.Web.HttpContext.Current.Session["Kullanici"];
                    string UUID = System.Web.HttpContext.Current.Session["RESIMUUID"].ToString();
                    //Save Image
                    string path = Path.Combine(Server.MapPath("~/Assets/Images/Uploads"), Path.GetFileName(Request.Files[i].FileName));
                    Request.Files[i].SaveAs(path);

                    //Save Thump
                    string path2 = Path.Combine(Server.MapPath("~/Assets/Images/Uploads"), "thump_" + Path.GetFileName(Request.Files[i].FileName));
                    Image img = ScaleImage(Image.FromStream(Request.Files[i].InputStream), 75, 75);
                    img.Save(path2);

                    resim.ResimYolu = Path.GetFileName(Request.Files[i].FileName);
                    resim.ThumpResimYolu = "thump_" + Path.GetFileName(Request.Files[i].FileName);
                    resim.Title = Path.GetFileName(Request.Files[i].FileName);
                    resim.ElementTypeId = 1;
                    resim.UUID = UUID;
                    resim.EkleyenId = k.Id;
                    resim.EklemeZamani = DateTime.Now;
                    resim.GuncelleyenId = k.Id;
                    resim.Guncellemezamani = DateTime.Now;
                    resim.Aktif = 1;
                    resimlist.Add(resim);

                }
                catch (Exception e)
                {

                    throw new HttpException(e.Message);
                }
            }
            foreach (var item in resimlist)
            {
                db.Resimler.Add(item);
                db.SaveChanges();
            }
            return Json(resimlist, JsonRequestBehavior.AllowGet);


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
    }
}