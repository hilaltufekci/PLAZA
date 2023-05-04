using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvckatmani.Models
{
    public class mvcHizmetModel
    {
        public int HizmetNo { get; set; }
        [required(ErrorMessage = "Zorunlu Alan")]
        public string HizmetAdi { get; set; }
        public int? HizmetSüresi { get; set; }
    }
}