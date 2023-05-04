using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvckatmani.Models;
using System.Net.Http;

namespace mvckatmani.Controllers
{
    public class HizmetKullaniciController : Controller
    {
        // GET: HizmetKullanici
        public ActionResult Index()
        {
            IEnumerable<mvcHizmetModel> listele;
            HttpResponseMessage response = Hizmet.webapiclient.GetAsync("Hizmetlers").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<mvcHizmetModel>>().Result;
            return View(listele);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcHizmetModel());
            }
            else
            {
                HttpResponseMessage response = Hizmet.webapiclient.GetAsync("Hizmetlers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcHizmetModel>().Result);
            }

        }
        [HttpPost]
        public ActionResult EY(mvcHizmetModel hizmet)
        {
            if (hizmet.HizmetNo == 0)
            {
                HttpResponseMessage response = Hizmet.webapiclient.PostAsJsonAsync("Hizmetlers", hizmet).Result;
            }
            else
            {
                HttpResponseMessage response = Hizmet.webapiclient.PutAsJsonAsync("Hizmetlers/" + hizmet.HizmetNo, hizmet).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = Hizmet.webapiclient.DeleteAsync("Hizmetlers/" + id.ToString()).Result;
            return RedirectToAction("Index");

        }
    }
}