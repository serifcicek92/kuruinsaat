using kuruinsaat.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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


        [HttpPost]
        public ActionResult ProjeEkle(Proje proje)
        {

            try
            {
                ResimUpdate(1, 1, "");//create edilen id alınacak uuid den resimlere atanacak
                System.Web.HttpContext.Current.Session.Remove("RESIMUUID");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ProjeList() {
            return View();
        }

        [HttpPost]
        public void ResimYukle(Resim resim)
        {
            int imageCount = Request.Files.Count;
            for (int i = 0; i < imageCount; i++)
            {
                //Save Image
                string path = Path.Combine(Server.MapPath("~/Assets/Images/UploadedFiles"), Path.GetFileName(Request.Files[i].FileName));
                Request.Files[i].SaveAs(path);

                //Save Thump
                string path2 = Path.Combine(Server.MapPath("~/Assets/Images/UploadedFiles"), "thump_"+Path.GetFileName(Request.Files[i].FileName));
                Image img = ScaleImage(Image.FromStream(Request.Files[i].InputStream), 75, 75);
                img.Save(path2);


            }
            
            if (System.Web.HttpContext.Current.Session["RESIMUUID"] != null && System.Web.HttpContext.Current.Session["RESIMUUID"].ToString().Equals(""))
                System.Web.HttpContext.Current.Session.Add("RESIMUUID", Guid.NewGuid());

        }

        // GET: Security/Edit/5
        public void ResimUpdate(int elementTypNo, int ElementId, string guuid)
        {

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