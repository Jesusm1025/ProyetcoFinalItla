using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PYF.Startup))]
namespace PYF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
