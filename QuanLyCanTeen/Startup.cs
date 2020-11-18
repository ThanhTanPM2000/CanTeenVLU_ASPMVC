using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLyCanTeen.Startup))]
namespace QuanLyCanTeen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
