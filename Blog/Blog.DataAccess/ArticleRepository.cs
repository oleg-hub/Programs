using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository(ApplicationContext context) : base (context)
        {
            
        }
    }
}
