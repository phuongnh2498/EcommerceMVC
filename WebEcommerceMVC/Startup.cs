using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebEcommerceMVC.Startup))]
namespace WebEcommerceMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
