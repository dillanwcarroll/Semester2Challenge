using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SSLChallengeWebApplication.Startup))]
namespace SSLChallengeWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
