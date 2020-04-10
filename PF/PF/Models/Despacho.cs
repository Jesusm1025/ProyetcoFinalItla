using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PF.Models
{
    public class Despacho
    {
        public int DespachoId { get; set; }
        public DateTime fecha { get; set; }
        public int TipoDeAccionId { get; set; }
        public TipoDeAccion TipoDeAccion { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}