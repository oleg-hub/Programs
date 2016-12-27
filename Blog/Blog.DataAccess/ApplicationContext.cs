using Blog.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser> //, IApplicationContext
    {
        public ApplicationContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }

}
