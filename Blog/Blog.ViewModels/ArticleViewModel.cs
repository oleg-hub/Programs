using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
   public class ArticleViewModel
    {
        public Article Article { get; set; }
        public List<Comment> Comments { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
    }
}
