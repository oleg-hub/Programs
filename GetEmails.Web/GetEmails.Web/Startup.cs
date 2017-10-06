using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GetEmails.Web.Startup))]
namespace GetEmails.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
