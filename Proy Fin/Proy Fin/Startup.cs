using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proy_Fin.Startup))]
namespace Proy_Fin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
