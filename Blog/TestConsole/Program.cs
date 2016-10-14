using Blog.DataAccess;
using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
     class Program
    {
        static void Main(string[] args)
        {
            Article article = new Article();
            article.Title = "Title";
            article.CreationDate = DateTime.Now;
            Service service = new Service();
            service.Save(article);
        }
       
       
        
    }
}
