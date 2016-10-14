using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Blog.Entities;
namespace Blog.DataAccess.Mapping
{
    public class ArticleMap : EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Title).IsRequired();
            Property(t => t.Text).IsRequired();
            Property(t => t.CreationDate).IsRequired();
            ToTable("Articles");
        }
    }
}