using Library.Entities.enums;

namespace Library.Entities
{
   public class Brochure : BaseEntity
    {
        public string BrochureNumber { get; set; }
        public string Title { get; set; }
        public CoverType CoverType { get; set; }
    }
}