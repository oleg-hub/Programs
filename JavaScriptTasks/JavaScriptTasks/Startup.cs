using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JavaScriptTasks.Startup))]
namespace JavaScriptTasks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
