using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrimerParcialJose.Startup))]
namespace PrimerParcialJose
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
