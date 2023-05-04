using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvckatmani.Models;
using System.Net.Http;

namespace mvckatmani.Controllers
{
    public class HizmetAdminController : Controller
    {
        // GET: HizmetAdmin
        public ActionResult Index()
        {
            IEnumerable<mvcHizmetModel> listele;
            HttpResponseMessage response = Hizmet.webapiclient.GetAsync("Hizmetlers").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<mvcHizmetModel>>().Result;
            return View(listele);
        }
    }
}