using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.DataAccess;
using Blog.Entities;
using Blog.Services;
using Blog.ViewModels;

namespace Blog.Controllers
{
    public class CommentController : Controller
    {
        ArticleService articleService = new ArticleService();
        private ApplicationContext db = new ApplicationContext();

        CommentService commentService = new CommentService();
        ArticleViewModel view = new ArticleViewModel();

        // GET: Comment
        public ActionResult Index()
        {
            view.Comments = commentService.GetComments().ToList();
            return View(view);
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.Article = new Article { Id = 1 , CreationDate = DateTime.Now};
                comment.CreationDate = DateTime.Now;
                commentService.Create(comment);
                return RedirectToAction("Index");
         //     return RedirectToAction("Article/Read/{0}", comment.Article.Id);
            }

            return View(comment);
        }

        // GET: Comment/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    view.Comment = commentService.Get(id);
        //    if (view == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(view);
        //}

        // POST: Comment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                commentService.Update(comment);
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            articleService.Delete(id);
            return View("Index");
        }
    }
}
