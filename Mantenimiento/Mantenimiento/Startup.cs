using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mantenimiento.Startup))]
namespace Mantenimiento
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
