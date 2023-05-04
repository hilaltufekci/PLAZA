using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvckatmani.Models;
using System.Net.Http;

namespace mvckatmani.Controllers
{
    public class BlokAdminController : Controller
    {
        // GET: BlokAdmin
        public ActionResult Index()
        {
            IEnumerable<mvcBlokModel> listele;
            HttpResponseMessage response = BlokAdmin.webapiclient.GetAsync("Bloklars").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<mvcBlokModel>>().Result;
            return View(listele);
     
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcBlokModel());
            }
            else
            {
                HttpResponseMessage response = BlokAdmin.webapiclient.GetAsync("Bloklars/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcBlokModel>().Result);
            }

        }
        [HttpPost]
        public ActionResult EY(mvcBlokModel blok)
        {
            if (blok.BlokNo == 0)
            {
                HttpResponseMessage response = BlokAdmin.webapiclient.PostAsJsonAsync("Bloklars", blok).Result;
            }
            else
            {
                HttpResponseMessage response = BlokAdmin.webapiclient.PutAsJsonAsync("Bloklars/" + blok.BlokNo, blok).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = BlokAdmin.webapiclient.DeleteAsync("Bloklars/" + id.ToString()).Result;
            return RedirectToAction("Index");

        }
    }
}