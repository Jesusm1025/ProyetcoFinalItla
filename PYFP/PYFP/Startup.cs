using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PYFP.Startup))]
namespace PYFP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
