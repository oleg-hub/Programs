using System.Collections.Generic;

namespace Library.Entities
{
    public class Book : BaseEntity
    {
        public string Autor { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Cover> Covers { get; set; }

        public Book()
        {
            Covers = new List<Cover>();
        }
    }
}
