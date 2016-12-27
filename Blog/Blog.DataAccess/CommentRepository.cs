using Blog.Entities;

namespace Blog.DataAccess
{
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(ApplicationContext context) : base(context)
        {
        }
    }
}