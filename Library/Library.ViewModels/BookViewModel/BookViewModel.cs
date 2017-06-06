using Library.Entities;
using System.Collections.Generic;

namespace Library.ViewModels.BookViewModel
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public List<PublishingHouse> ListOfPublishingHouse { get; set; }
        public List<PublishingHouse> PublishingHousesInBook { get; set; }
    }
}
