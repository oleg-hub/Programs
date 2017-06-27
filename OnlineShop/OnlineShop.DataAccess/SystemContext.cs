using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess
{
    public class SystemContext : DbContext
    {
        public SystemContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<SoldProduct> SoldProducts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentInProduct> CommentInProducts { get; set; }
        public DbSet<CartInSoldProduct> CartInSoldProducts { get; set; }

        //public static SystemContext Create()
        //{
        //    return new SystemContext();
        //}

    }
}