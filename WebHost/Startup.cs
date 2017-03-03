using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebHost.Startup))]

namespace WebHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            RestApi.Starter.Configuration(app);
        }
    }
}
