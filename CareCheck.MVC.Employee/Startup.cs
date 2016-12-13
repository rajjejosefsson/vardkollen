using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CareCheck.MVC.Employee.Startup))]
namespace CareCheck.MVC.Employee
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
