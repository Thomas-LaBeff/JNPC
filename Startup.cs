using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Church_App.Startup))]
namespace Church_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
