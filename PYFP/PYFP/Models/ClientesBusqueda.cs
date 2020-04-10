using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PYFP.Models
{
    public class ClientesBusqueda
    {
        public int clienteId { get; set; }
        public string Nombre { get; set; }
        public string TipoCliente { get; set; }
        public string RNC { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email  { get; set; }
    }
}