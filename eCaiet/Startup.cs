using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eCaiet.Startup))]
namespace eCaiet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
