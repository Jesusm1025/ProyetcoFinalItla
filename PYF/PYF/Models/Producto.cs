using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PYF.Models
{
    //Mantenimiento de productos: Atributos(Codigo, Fecha_Creacion, Fecha_Vencimiento, Nombre, Descripcion, UdM, Costo, Existencia, Estado)

    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public string udm { get; set; }
        public decimal Costo { get; set; }
        public int Existencia { get; set; }
        public ICollection<EstadoProducto> estado { get; set; }

    }
}