using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookingSystemFinalProject.Startup))]
namespace BookingSystemFinalProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
