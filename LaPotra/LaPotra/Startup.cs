using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaPotra.Startup))]
namespace LaPotra
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
