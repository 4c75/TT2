using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TT2_Gala_darbs.Startup))]
namespace TT2_Gala_darbs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
