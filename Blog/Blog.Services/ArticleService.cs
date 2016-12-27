using Blog.DataAccess;
using Blog.Entities;
using Blog.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Services
{
    public class ArticleService
    {
        ArticleRepository articleRepository;
        CommentRepository commentRepository;
        ApplicationContext context;
        public ArticleService()
        {
            context = new ApplicationContext();
            articleRepository = new ArticleRepository(context);
            commentRepository = new CommentRepository(context);
        }
        public List<Article> GetArticles()
        {
            return articleRepository.Get().OrderByDescending(c => c.CreationDate).ToList();
        }
        public List<ArticleAdminItemViewModel> GetKendoArticles()
        {
            return articleRepository.Get().OrderByDescending(c => c.CreationDate)
                .Select(x => new ArticleAdminItemViewModel
                {
                    CreationDate = x.CreationDate.ToShortDateString(),
                    Id = x.Id,
                    Text = x.Text,
                    Title = x.Title
                }).ToList();
        }
        public Article GetArticleByID(string id)
        {
            return articleRepository.GetByID(id);
        }
        public void AddNewArticle(Article article)
        {
            articleRepository.Insert(article);
            articleRepository.Save();
        }
        public void UpdateArticle(Article article)
        {
            articleRepository.Update(article);
            articleRepository.Save();
        }
        public void DeleteArticle(string id)
        {
            articleRepository.Delete(id);
            articleRepository.Save();
        }
    }
}