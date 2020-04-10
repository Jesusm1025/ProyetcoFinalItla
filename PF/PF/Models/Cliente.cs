using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PF.Models
{
    public class Cliente
    {
        //Mantenimiento de clientes: Atributos(Codigo, Nombre, Apellido, Direccion, Telefono, Correo, Tipo de cliente).
        //Tipos de clientes: Empresa o Persona fisica

        public int clienteId { get; set; }
        public string Nombre { get; set; }
        public int TipoClienteId { get; set; }
        public TipoCliente tipo { get; set; }
        public string RNC { get; set; }
        public ICollection<Telefono> Telefonos { get; set; }
        public ICollection<Direccion> Direcciones { get; set; }
        public ICollection<Email> Emails { get; set; }

    }
}