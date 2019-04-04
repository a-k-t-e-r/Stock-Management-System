using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stock_Management_System.Startup))]
namespace Stock_Management_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
