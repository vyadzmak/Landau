using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Landau.Startup))]
namespace Landau
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
