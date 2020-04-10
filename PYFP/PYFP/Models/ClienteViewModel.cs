using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PYFP.Models
{
    public class ClienteViewModel
    {
        private ApplicationDbContext contexto;
        public ClienteViewModel() 
        {
            contexto = new ApplicationDbContext();
            clientes = new List<ClientesBusqueda>();
        }
        public List<ClientesBusqueda> clientes { get; set; }
        public void BuscarPorNombre(string Busqueda)
        {
            var consulta = from c in contexto.Clientes
                           where c.Nombre.Contains(Busqueda)
                           select new
                           {
                               c.clienteId,
                               c.RNC,
                               c.tipo,
                               Tipo = c.tipo.NombreTipo ?? "",
                               NombreCliente = c.Nombre,
                               Correo = c.Email,
                               Telefono = c.Telefono,
                               Direccion = c.Direccion
                           };
            clientes.Clear();
            if(consulta != null)
            {
                var lclientes = consulta.ToList();
                foreach (var item in lclientes)
                {
                    clientes.Add(new ClientesBusqueda
                    {
                        clienteId = item.clienteId,
                        Nombre = item.NombreCliente,
                        RNC = item.RNC,
                        TipoCliente = item.Tipo,
                        Email = item.Correo,
                        Telefono = item.Telefono,
                        Direccion = item.Direccion
                    });
                }
            }
        }
    }
}