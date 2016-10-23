using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeeTime.Startup))]
namespace TeeTime
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
