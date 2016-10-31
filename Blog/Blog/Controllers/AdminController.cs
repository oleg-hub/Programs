using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Web.Models;
using Blog.Entities;
using Blog.DataAccess;
using Blog.Services;
using Blog.ViewModels;

namespace Blog.Web.Controllers
{
    public class AdminController : Controller
    {
        ArticleService articleService = new ArticleService();
        ArticleViewModel view = new ArticleViewModel();

        public ActionResult Index()
        {
        //    view.Articles = articleService.GetArticles();
            return View(view);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            view.Article = articleService.Get(id);
            if (view == null)
            {
                return HttpNotFound();
            }
            return View(view);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                articleService.Create(article);
                return RedirectToAction("Index");
            }
            return View(view.Article);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            view.Article = articleService.Get(id);
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
                articleService.Update(article);
                return RedirectToAction("Index");
            }
            return View(view);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           view.Article = articleService.Get(id);
            if (view == null)
            {
                return HttpNotFound();
            }
            return View(view);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             articleService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}