using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eventux.Backend.Startup))]
namespace Eventux.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
