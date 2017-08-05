using System.Web;
using System.Web.Mvc;

namespace Ulatina.Electiva.Classwork.Proyecto.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
