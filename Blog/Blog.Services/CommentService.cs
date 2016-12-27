using Blog.DataAccess;
using Blog.Entities;
using Blog.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Services
{
    public class CommentService
    {
        ApplicationContext context;
        CommentRepository commentRepository;
        ArticleRepository articleRepository;

        public CommentService()
        {
            context = new ApplicationContext();
            commentRepository = new CommentRepository(context);
            articleRepository = new ArticleRepository(context);
        }
        public List<Comment> GetComments(string articleId)
        {
            List<Comment> comments = commentRepository.Get(x => x.Article.Id == articleId).OrderByDescending(date => date.CreationDate).ToList();
            return comments;
        }
        public void AddNewComment(EntitiesViewModels model)
        {
            Comment comment = new Comment();
            comment.UserName = model.UserName;
            comment.Text = model.Text;
            comment.Article = articleRepository.GetByID(model.Article.Id);
            commentRepository.Insert(comment);
            commentRepository.Save();
        }
        public void DeleteComment(string id)
        {
            commentRepository.Delete(id);
            commentRepository.Save();
        }
    }
}
