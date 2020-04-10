//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mantenimiento.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.Despachoes = new HashSet<Despacho>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> Fecha_Creacion { get; set; }
        public Nullable<System.DateTime> Fecha_Vencimiento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string udm { get; set; }
        public decimal Costo { get; set; }
        public int Existencia { get; set; }
        public int idEstado { get; set; }
    
        public virtual EstadoProducto EstadoProducto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Despacho> Despachoes { get; set; }
    }
}
