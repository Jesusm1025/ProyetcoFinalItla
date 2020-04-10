using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PF.Models
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
                               Correo = (from e in c.Emails where e.Principal select e.Dirrecion).FirstOrDefault() ?? "",
                               Telefono = (from t in c.Telefonos where t.Principal select t.NumeroTelefonico).FirstOrDefault() ?? "",
                               Direccion = (from d in c.Direcciones
                                            where d.Principal
                                            select d.Calle + " " + d.Provincia + " " + d.Municipio + " ").FirstOrDefault() ?? ""
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