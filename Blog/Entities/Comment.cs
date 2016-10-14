using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Entities
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual Article Article { get; set; }
    }
}