using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace mvckatmani
{
    public static class PlazaAdmin
    {
        public static HttpClient webapiclient = new HttpClient(); //websitenin urlsine bağlanıcak.aşağıdaki
        //constructor?

        static PlazaAdmin()
        {
            webapiclient.BaseAddress = new Uri("https://localhost:44346/api/"); //apinin urlsini eklicez.
            webapiclient.DefaultRequestHeaders.Clear(); //dönen sonuç başlıkllarını hemen temizle.aynı başlıkta sbait kalmasın.
            webapiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicarion/json"));// json formatında verilerimi getir.
        }

    }
}