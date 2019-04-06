using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCparcialJose.Startup))]
namespace MVCparcialJose
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
