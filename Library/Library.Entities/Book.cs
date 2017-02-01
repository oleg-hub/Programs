using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Entities
{
    public class Book : BaseEntity
    {
        public string Autor { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Cover> Covers { get; set; }
        public virtual ICollection<PublishingHouse> PublishingHouses { get; set; }

        public Book()
        {
            Covers = new List<Cover>();
            PublishingHouses = new List<PublishingHouse>();

        }
    }
}
