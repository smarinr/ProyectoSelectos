using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ulatina.Electiva.Classwork.Proyecto.MVC.Startup))]
namespace Ulatina.Electiva.Classwork.Proyecto.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
