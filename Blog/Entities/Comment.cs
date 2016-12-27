using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
    public class Comment : BaseEntity
    {
        public string UserName { get; set; }
        public string Text { get; set; }
        public virtual Article Article { get; set; }
    }
}