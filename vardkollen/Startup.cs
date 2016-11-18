using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(demopurpose.Startup))]
namespace demopurpose
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
