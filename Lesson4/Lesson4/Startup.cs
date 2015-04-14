using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lesson4.Startup))]
namespace Lesson4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
