using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Blog.Entities;
using Blog.Services;
using Blog.ViewModels;
using Blog.Web.Helper;

namespace Blog.Web.Controllers
{
    public class ArticleController : Controller

    {
        CommentService commentService;
        ArticleService articleService;
        public ArticleController()
        {
            commentService = new CommentService();
            articleService = new ArticleService();
        }
        public ActionResult Index()
        {
            List<Article> articleList = articleService.GetArticles();
            List<EntitiesViewModels> articleViewModelList = new List<EntitiesViewModels>();
            foreach (var article in articleList)
            {
                EntitiesViewModels model = new EntitiesViewModels { Article = article };
                articleViewModelList.Add(model);
            }
            return View(articleViewModelList);
        }

        public ActionResult ReadArticle(string id)
        {
            EntitiesViewModels model = new EntitiesViewModels();
            model.Article = articleService.GetArticleByID(id);
            model.Comments = commentService.GetComments(id);
            return View(model);
        }

        public ActionResult AddComment(EntitiesViewModels model)
        {
            if (model.UserName != null && model.Text != null)
            {
                commentService.AddNewComment(model);
            }
            model.Comments = commentService.GetComments(model.Article.Id);
            return PartialView(model);
        }

        public ActionResult DeleteComment(string id, string articleId)
        {
            EntitiesViewModels model = new EntitiesViewModels();
            commentService.DeleteComment(id);
            model.Comments = commentService.GetComments(articleId);
            return PartialView("AddComment", model);
        }
    }
}