using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvckatmani.Models
{
    public class mvcPersonelModel
    {
        public int PersonelNo { get; set; }
        [required(ErrorMessage = "Zorunlu Alan")]
        public string PersonelAdi { get; set; }
        public string PersonelSoyad { get; set; }
        public int? PersonelYas { get; set; }
    }
}