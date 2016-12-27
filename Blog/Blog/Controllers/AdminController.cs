using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Blog.Entities;
using Blog.Services;
using Blog.ViewModels;
using Blog.Web.Models;
using System.Web.Security;
using Blog.DataAccess;
using Microsoft.AspNet.Identity.EntityFramework;
using Blog.Web.Helper;

namespace Blog.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        ArticleService articleService;
        AccountService accountService;
        EntitiesViewModels view;
        RegisterViewModel model;
        public AdminController()
        {
            articleService = new ArticleService();
            accountService = new AccountService();
            view = new EntitiesViewModels();
            model = new RegisterViewModel();

        }
        public ActionResult Index()
        {
            model.ApplicationUsers = accountService.GetListAdmins();
            return View(model);
        }

        public JsonResult GetAllArticle()
        {
            var articleList = articleService.GetKendoArticles();
            return Json(articleList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllAdmin()
        {
            var adminList = accountService.GetKendoAdmins();
            return Json(adminList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article)
        {
            if (article.Title != null && article.Text != null)
            {
                articleService.AddNewArticle(article);
                return RedirectToAction("Index");
            }
            return View(view.Article);
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            view.Article = articleService.GetArticleByID(id);
            if (view == null)
            {
                return HttpNotFound();
            }
            return View(view);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                articleService.UpdateArticle(article);
                return RedirectToAction("Index");
            }
            return View(view);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            view.Article = articleService.GetArticleByID(id);
            if (view == null)
            {
                return HttpNotFound();
            }
            return View(view);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            articleService.DeleteArticle(id);
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult DeleteUser(string id)
        {
            accountService.DeleteUser(id);
            model.ApplicationUsers = accountService.GetListAdmins();
            return RedirectToAction("Index");
        }
    }
}
