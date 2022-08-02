using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TuFicha.Startup))]
namespace TuFicha
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
