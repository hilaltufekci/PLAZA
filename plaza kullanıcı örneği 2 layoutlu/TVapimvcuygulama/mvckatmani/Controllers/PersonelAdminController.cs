using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvckatmani.Models;
using System.Net.Http;


namespace mvckatmani.Controllers
{
    public class PersonelAdminController : Controller
    {
        // GET: PersonelAdmin
        public ActionResult Index()
        {
                IEnumerable<mvcPersonelModel> listele;
                HttpResponseMessage response = Personel.webapiclient.GetAsync("Personellers").Result;
                listele = response.Content.ReadAsAsync<IEnumerable<mvcPersonelModel>>().Result;
                return View(listele);
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = Personel.webapiclient.DeleteAsync("Personellers/" + id.ToString()).Result;
            return RedirectToAction("Index");

        }
    }
}