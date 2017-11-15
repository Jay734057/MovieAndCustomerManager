using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieAndCustomerManager.Startup))]
namespace MovieAndCustomerManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
