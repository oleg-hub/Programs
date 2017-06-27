using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Entities
{
    public class CommentInProduct : BaseEntity
    {
        public virtual string ProductId { get; set; }
        public virtual string CommentId { get; set; }
    }
}
