using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(User.Startup))]
namespace User
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
