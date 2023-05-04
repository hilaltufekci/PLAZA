using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvckatmani.Models;
using System.Net.Http;


namespace mvckatmani.Controllers
{
    public class GorevKullaniciController : Controller
    {
        // GET: GorevKullanici
        public ActionResult Index()
        {

            IEnumerable<mvcGorevModel> listele;
            HttpResponseMessage response = Gorev.webapiclient.GetAsync("Görevlers").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<mvcGorevModel>>().Result;
            return View(listele);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcGorevModel());
            }
            else
            {
                HttpResponseMessage response = Gorev.webapiclient.GetAsync("Görevlers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcGorevModel>().Result);
            }

        }
        [HttpPost]
        public ActionResult EY(mvcGorevModel gorev)
        {
            if (gorev.GörevNo == 0)
            {
                HttpResponseMessage response = Gorev.webapiclient.PostAsJsonAsync("Görevlers", gorev).Result;
            }
            else
            {
                HttpResponseMessage response = Gorev.webapiclient.PutAsJsonAsync("Görevlers/" + gorev.GörevNo, gorev).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = Gorev.webapiclient.DeleteAsync("Görevlers/" + id.ToString()).Result;
            return RedirectToAction("Index");

        }
    }
}