using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(GoDrive.Web.Startup))]

namespace GoDrive.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
