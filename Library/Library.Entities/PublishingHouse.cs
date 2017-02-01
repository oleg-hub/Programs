using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class PublishingHouse : BaseEntity
    {
        public string Name { get; set; }
        public int YearOfEstablishment { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public PublishingHouse()
        {
            Books = new List<Book>();
        }
    }
}
