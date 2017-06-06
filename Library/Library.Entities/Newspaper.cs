
namespace Library.Entities
{
   public class Newspaper : BaseEntity
    {
        public string Title { get; set; }
        public int QuantityOfArticles { get; set; }
        public string ChiefEditor { get; set; }
    }
}
