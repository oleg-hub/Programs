using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}