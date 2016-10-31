using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Web.Models;
using Blog.Entities;
using Blog.Services;
using Blog.ViewModels;

namespace Blog.Web.Controllers
{
    public class ArticleController : Controller
    {
        CommentService commentService = new CommentService();
        ArticleService articleService = new ArticleService();

        public ActionResult Index()
        {
            List<Article> articleList = articleService.GetArticles().ToList();
            List<ArticleViewModel> articleViewModelList = new List<ArticleViewModel>();
            foreach (var article in articleList)
            {
                ArticleViewModel model = new ArticleViewModel { Article = article };
                articleViewModelList.Add(model);
            }
            return View(articleViewModelList);
        }
        [HttpGet]
        public ActionResult Read(int id)
        {
            ArticleViewModel viewModel = new ArticleViewModel();
            viewModel.Article = articleService.Get(id);

            //List<Comment> comments = articleService.GetComments(id);
            //viewModel.Comments.AddRange(comments);
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Read(ArticleViewModel model)
        {
           Article article = articleService.Get(model.Article.Id);
            Comment comment = new Comment { UserName = model.UserName, Text = model.Text, Article = article };
            commentService.Create(comment);
            return RedirectToAction("Index");
            //    return RedirectToAction("Read/{0}", comment.Article.Id);
        }
    }
}