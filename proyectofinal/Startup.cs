using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proyectofinal.Startup))]
namespace proyectofinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
