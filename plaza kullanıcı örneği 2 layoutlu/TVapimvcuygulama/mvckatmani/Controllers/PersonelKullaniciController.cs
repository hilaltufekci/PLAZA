using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvckatmani.Models;
using System.Net.Http;

namespace mvckatmani.Controllers
{
    public class PersonelKullaniciController : Controller
    {
        // GET: PersonelKullanici
        public ActionResult Index()
        {
            IEnumerable<mvcPersonelModel> listele;
            HttpResponseMessage response = Personel.webapiclient.GetAsync("Personellers").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<mvcPersonelModel>>().Result;
            return View(listele);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcPersonelModel());
            }
            else
            {
                HttpResponseMessage response = Personel.webapiclient.GetAsync("Personellers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcPersonelModel>().Result);
            }

        }
        [HttpPost]
        public ActionResult EY(mvcPersonelModel personel)
        {
            if (personel.PersonelNo == 0)
            {
                HttpResponseMessage response = Personel.webapiclient.PostAsJsonAsync("Personellers", personel).Result;
            }
            else
            {
                HttpResponseMessage response = Personel.webapiclient.PutAsJsonAsync("Personellers/" + personel.PersonelNo, personel).Result;
            }
            return RedirectToAction("Index");
        }
    }
}