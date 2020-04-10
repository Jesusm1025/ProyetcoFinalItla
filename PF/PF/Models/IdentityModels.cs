using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PF.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string NombreCompleto { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("NombreCompleto", this.NombreCompleto));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PF.Models.Cliente> Clientes { get; set; }
        public System.Data.Entity.DbSet<PF.Models.Producto> Productos { get; set; }
        public System.Data.Entity.DbSet<PF.Models.Despacho> Despachos { get; set; }
        public System.Data.Entity.DbSet<PF.Models.Direccion> Direcciones  { get; set; }
        public System.Data.Entity.DbSet<PF.Models.Email>  Emails { get; set; }
        public System.Data.Entity.DbSet<PF.Models.EstadoProducto> EstadoProductos { get; set; }
        public System.Data.Entity.DbSet<PF.Models.Telefono> Telefonos  { get; set; }
        public System.Data.Entity.DbSet<PF.Models.TipoCliente> TipoClientes { get; set; }
        public System.Data.Entity.DbSet<PF.Models.TipoDeAccion> TipoDeAcciones  { get; set; }
        public System.Data.Entity.DbSet<PF.Models.UdM> UdMs { get; set; }
    }
}