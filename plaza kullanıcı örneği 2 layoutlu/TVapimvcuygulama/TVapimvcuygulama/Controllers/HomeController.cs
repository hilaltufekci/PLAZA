using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TVapimvcuygulama.Models;

namespace TVapimvcuygulama.Controllers
{
    public class HomeController : Controller
    {
        apimvcuygulamaEntities3 db = new apimvcuygulamaEntities3();
        public ActionResult Index()
        {
            return View(db.Kullanicilars.ToList());
        }
        public ActionResult SıgnUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SıgnUp(Kullanicilar kullanicilar)
        {
            if (db.Kullanicilars.Any(x => x.KullaniciAdi == kullanicilar.KullaniciAdi))
            {
                ViewBag.Notification = "Böyle kişi var"; //viewbag:controllerden veri gönderilmesini sağlayacak
            }
            else
            {
                db.Kullanicilars.Add(kullanicilar);
                db.SaveChanges();
                Session["KullaniciNo"] = kullanicilar.KullaniciNo.ToString();
                Session["KullaniciAdi"] = kullanicilar.KullaniciAdi.ToString();
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //doğru kişimi giriyor diye kontrol yapıyor.
        public ActionResult Login(Kullanicilar kullanicilar)
        {
            var loginkontrol = db.Kullanicilars.Where(x => x.KullaniciAdi.Equals(kullanicilar.KullaniciAdi) && x.Sifre.Equals(kullanicilar.Sifre)).FirstOrDefault();
            if (loginkontrol != null)
            {
                Session["KullaniciNo"] = kullanicilar.KullaniciNo.ToString();
                Session["KullaniciAdi"] = kullanicilar.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Yanlış Kullanıcı Adı veya Şifre Tekrar deneyiniz.";
            }
            return View();
        }

    }
}
