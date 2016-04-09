using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeAssist.Startup))]
namespace EmployeeAssist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
