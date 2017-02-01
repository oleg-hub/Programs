using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
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
                return id ?? (id = Guid.NewGuid().ToString());
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
