using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess
{
    class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
