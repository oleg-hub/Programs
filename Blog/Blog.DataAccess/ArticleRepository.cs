using Blog.Entities;

namespace Blog.DataAccess
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(ApplicationContext context) : base (context)
        {
        }
    }
}
