using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SeleniumDemo.Startup))]
namespace SeleniumDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
