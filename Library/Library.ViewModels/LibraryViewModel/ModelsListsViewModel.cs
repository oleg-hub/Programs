using Library.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Library.ViewModels
{
    public class ModelsListsViewModel
    {
        public List<Book> Books { get; set; }
        public List<Magazine> Magazines { get; set; }
        public List<Brochure> Brochures { get; set; }
        public List<Newspaper> Newspapers { get; set; }
        public List<PublishingHouse> PublishingHouses { get; set; }
        public MultiSelectList MultiSelectListBooks { get; set; }
        public MultiSelectList MultiSelectListPublishingHouses { get; set; }
        public List<BookInPublishingHouse> BooksInPublishingHouse { get; set; }
    }
}
