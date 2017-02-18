using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(nastha.Startup))]
namespace nastha
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
