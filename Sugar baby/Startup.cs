using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sugar_baby.Startup))]
namespace Sugar_baby
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
