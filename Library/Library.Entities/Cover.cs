using System.Collections.Generic;


namespace Library.Entities
{
    public class Cover : BaseEntity
    {
        public byte[] CoverForModels { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Magazine> Magazines { get; set; }

        public Cover()
        {
            Books = new List<Book>();
            Magazines = new List<Magazine>();
        }
    }
}

