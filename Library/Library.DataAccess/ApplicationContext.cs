using Library.Entities;
using System.Data.Entity;

namespace Library.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Brochure> Brochures { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<Newspaper> Newspapers { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
    }
}
