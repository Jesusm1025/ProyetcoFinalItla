using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PYFP.Models
{
    public class Despacho
    {
        public int DespachoId { get; set; }
        public DateTime fecha { get; set; }
        public TipoDeAccion tipodeaccion { get; set; }
        public Cliente Cliente { get; set; }
        public Producto Producto { get; set; }
    }
}