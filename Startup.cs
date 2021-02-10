using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Starset.Startup))]
namespace Starset
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            //app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
        }
    }
}
