using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        ModelModel m = new ModelModel();
        public ActionResult Index()
        {

            
            return View(m);
        }

        public PartialViewResult PartialV()
        {

            //ModelModel m = new ModelModel();
            //HttpPostedFileBase model = null;
            //var length = model.InputStream.Length;
            //byte[] fileData = null;
            //using (var binaryReader = new BinaryReader(model.InputStream))
            //{
            //    fileData = binaryReader.ReadBytes(model.ContentLength);
            //}
            //m.TopBar = fileData;

            return PartialView(m);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase model)
        {

            ModelModel m = new ModelModel();

            if (model != null)
            {
                var length = model.InputStream.Length;
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(model.InputStream))
                {
                    fileData = binaryReader.ReadBytes(model.ContentLength);
                }
                m.TopBar = fileData;
            }
            

            return View(m);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}