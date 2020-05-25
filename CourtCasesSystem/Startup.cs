using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourtCasesSystem.Startup))]
namespace CourtCasesSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
