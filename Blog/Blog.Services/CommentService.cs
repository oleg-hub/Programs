using Blog.DataAccess;
using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services
{
   public class CommentService
    {
        ApplicationContext context;
        CommentRepository commentRepository;
        public CommentService()
        {
            context = new ApplicationContext(); 
            commentRepository = new CommentRepository(context);
        }
        public IEnumerable<Comment> GetComments()
        {
            return commentRepository.Get();
        }
        public Comment Get(int? id)
        {
            return commentRepository.GetByID(id);
        }
        public void Create(Comment comment)
        {
            comment.CreationDate = DateTime.Now;
            commentRepository.Insert(comment);
            commentRepository.Save();
        }
        public void Update(Comment comment)
        {
            comment.CreationDate = DateTime.Now;
            commentRepository.Update(comment);
            commentRepository.Save();
        }
        public void Delete(int id)
        {
            commentRepository.Delete(id);
            commentRepository.Save();
        }
    }
}
