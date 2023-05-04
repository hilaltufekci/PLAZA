using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace mvckatmani
{
    public static class BlokAdmin
    {
        public static HttpClient webapiclient = new HttpClient();

        static BlokAdmin()
        {
            webapiclient.BaseAddress = new Uri("https://localhost:44346/api/");
            webapiclient.DefaultRequestHeaders.Clear();
            webapiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicarion/json"));
        }
    }

}