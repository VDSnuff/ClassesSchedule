using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClassesSchedule.Startup))]
namespace ClassesSchedule
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
