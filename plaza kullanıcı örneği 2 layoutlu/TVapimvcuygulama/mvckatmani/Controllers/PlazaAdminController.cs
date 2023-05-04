using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvckatmani.Models;
using System.Net.Http;

namespace mvckatmani.Controllers
{
    public class PlazaAdminController : Controller
    {
        // GET: PlazaAdmin
        public ActionResult Index()
        {

            IEnumerable<mvcPlazaModel> listele;
            HttpResponseMessage response = PlazaAdmin.webapiclient.GetAsync("Plazalars").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<mvcPlazaModel>>().Result;
            return View(listele);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcPlazaModel());
            }
            else
            {
                HttpResponseMessage response = PlazaAdmin.webapiclient.GetAsync("Plazalars/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcPlazaModel>().Result);
            }

        }
        [HttpPost]
        public ActionResult EY(mvcPlazaModel plaza)
        {
            if (plaza.PlazaNo == 0)
            {
                HttpResponseMessage response = PlazaAdmin.webapiclient.PostAsJsonAsync("Plazalars", plaza).Result;
            }
            else
            {
                HttpResponseMessage response = PlazaAdmin.webapiclient.PutAsJsonAsync("Plazalars/" + plaza.PlazaNo, plaza).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = PlazaAdmin.webapiclient.DeleteAsync("Plazalars/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }

        }
    }