using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CareCheck.MVC.Relatives.Startup))]
namespace CareCheck.MVC.Relatives
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
