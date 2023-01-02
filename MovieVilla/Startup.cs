using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieVilla.Startup))]
namespace MovieVilla
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
