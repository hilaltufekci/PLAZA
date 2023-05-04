using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvckatmani.Models
{
    public class mvcBlokModel
    {
        public int BlokNo { get; set; }
        [required(ErrorMessage = "Zorunlu Alan")]
        public string BlokAdi { get; set; }
        public int? BlokSayisi { get; set; }

    }
}