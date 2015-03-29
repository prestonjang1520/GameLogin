using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameLogin.Startup))]
namespace GameLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
