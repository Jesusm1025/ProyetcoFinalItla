using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PYF.Models
{
    public class Despacho
    {
        public int DespachoId { get; set; }
        public DateTime fecha { get; set; }
        public TipoDeAccion tipodeaccion { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Producto Producto { get; set; }
    }
}