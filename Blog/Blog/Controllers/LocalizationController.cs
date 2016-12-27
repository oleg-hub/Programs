using Blog.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class LocalizationController : Controller
    {
        public ActionResult Change(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            List<string> culture = new List<string>() { "ru-Ru", "en-GB" };
            if (!culture.Contains(lang))
            {
                lang = "ru-Ru";
            }
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
            {
                cookie.Value = lang;
            }
            else
            {
                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }

            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
    }
}