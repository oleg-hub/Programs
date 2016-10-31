using Blog.DataAccess;
using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class ArticleService
    {
        ArticleRepository articleRepository;
        CommentRepository commentRepository;
        public ArticleService()
        {
            articleRepository = new ArticleRepository(new ApplicationContext());
            commentRepository = new CommentRepository(new ApplicationContext());
        }
        public IEnumerable<Article> GetArticles()
        {
            return articleRepository.Get();
        }
        public List<Comment> GetComments(int articleId)
        {
            return commentRepository.Get().Where(x => x.Article.Id == articleId).ToList();
        }
        public Article Get(int? id)
        {
            return articleRepository.GetByID(id);
        }
        public void Create(Article article)
        {
            article.CreationDate = DateTime.Now;
            articleRepository.Insert(article);
            articleRepository.Save();
        }
        public void Update(Article article)
        {
            article.CreationDate = DateTime.Now;
            articleRepository.Update(article);
            articleRepository.Save();
        }
        public void Delete(int id)
        {
            articleRepository.Delete(id);
            articleRepository.Save();
        }
    }
}