using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PF.Models
{
    public class Direccion
    {
        public int DireccionId { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public string barrio { get; set; }
        public string Calle { get; set; }
        public bool Principal { get; set; }

    }
}