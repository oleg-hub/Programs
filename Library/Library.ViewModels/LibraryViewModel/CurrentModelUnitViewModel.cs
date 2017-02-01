using Library.Entities;
using System.Collections.Generic;

namespace Library.ViewModels
{
   public class CurrentModelUnitViewModel
    {
        public Book Book { get; set; }
        public Magazine Magazine { get; set; }
        public Brochure Brochure { get; set; }
        public Newspaper Newspaper { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
        public List<Book> ListOfBooks { get; set; }
        public List<PublishingHouse> ListOfPublishingHouse { get; set; }

    }
}
