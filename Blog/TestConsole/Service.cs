using Blog.DataAccess;
using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class Service
    {
        private ApplicationContext context;
        private ArticleRepository articleRepository;
        public Service()
        {
            context = new ApplicationContext();
            articleRepository = new ArticleRepository(context);
        }
        public void Save(Article article)
        {            
            articleRepository.Insert(article);
            articleRepository.Save();
        }
    }
}