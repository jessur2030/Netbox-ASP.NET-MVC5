using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Netbox.Startup))]
namespace Netbox
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
