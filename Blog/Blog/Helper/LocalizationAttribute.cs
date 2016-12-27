using System.Collections.Generic;
using System.Web;
using System.Threading;
using System.Globalization;
using System.Web.Mvc;

namespace Blog.Web.Helper
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        private string _DefaultLanguage = "ru-Ru";
        public LocalizationAttribute(string defaultLanguage)
        {
            _DefaultLanguage = defaultLanguage;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string cultureName = null;
            HttpCookie cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else
            {
                cultureName = "ru-Ru";
            }
            List<string> culture = new List<string>() { "ru-Ru", "en-GB" };
            if (!culture.Contains(cultureName))
            {
                cultureName = "ru-Ru";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
        }
    }
}