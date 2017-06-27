using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Entities
{
   public class Comment : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
    }
}
