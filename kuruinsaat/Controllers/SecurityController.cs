using kuruinsaat.Entity;
using kuruinsaat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace kuruinsaat.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            var kullanicidb = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == kullanici.KullaniciAdi && x.Parola == kullanici.Parola);
            if (kullanicidb != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.KullaniciAdi, false);
                System.Web.HttpContext.Current.Session.Add("Kullanici", kullanicidb);
                return RedirectToAction("Index", "Yonetim");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz kullanıcı yada parola. Lütfen kotnrol ediniz.";
                return View();
            }
        }

        // GET: Security/Create
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        // POST: Security/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      

        // POST: Security/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Security/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
