using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebEcommerceMVC.WebUI.Startup))]
namespace WebEcommerceMVC.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
