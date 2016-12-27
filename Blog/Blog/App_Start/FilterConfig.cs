using Blog.Web.Helper;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LocalizationAttribute("ru-Ru"), 0);
        }
    }
}