using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DABongDa.Startup))]
namespace DABongDa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
