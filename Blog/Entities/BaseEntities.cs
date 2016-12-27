using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
    public abstract class BaseEntity
    {
        private string id;
        [Key]
        [Required]
        public string Id
        {
            get
            {
                return id ?? (id = Guid.NewGuid().ToString  ());
            }
            set
            {
                id = value;
            }
        }
        [Required]
        public DateTime CreationDate
        {
            get;
            protected set;
        }

        protected BaseEntity()
        {
            CreationDate = DateTime.Now; 
        }
    }
}