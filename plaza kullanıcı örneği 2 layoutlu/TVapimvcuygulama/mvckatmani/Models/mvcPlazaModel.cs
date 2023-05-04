using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvckatmani.Models
{
    public class mvcPlazaModel
    {
        public int PlazaNo { get; set; }
        [required(ErrorMessage ="Zorunlu Alan")]
        public string PlazaAdi { get; set; }
        public int? PlazaKatSayisi { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
    }
}