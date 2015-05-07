using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Juega.Startup))]
namespace Juega
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
