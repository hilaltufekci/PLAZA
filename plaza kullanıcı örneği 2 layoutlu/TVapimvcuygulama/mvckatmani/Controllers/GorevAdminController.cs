using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvckatmani.Models;
using System.Net.Http;

namespace mvckatmani.Controllers
{
    public class GorevAdminController : Controller
    {
        // GET: GorevAdmin
        public ActionResult Index()
        {
                IEnumerable<mvcGorevModel> listele;
                HttpResponseMessage response = Gorev.webapiclient.GetAsync("Görevlers").Result;
                listele = response.Content.ReadAsAsync<IEnumerable<mvcGorevModel>>().Result;
                return View(listele);
            
        }
    }
}