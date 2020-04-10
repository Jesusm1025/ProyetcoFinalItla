using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PF.Startup))]
namespace PF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
