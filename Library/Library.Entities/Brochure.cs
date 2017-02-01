using Library.Entities.enums;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
   public class Brochure : BaseEntity
    {
       
        public string BrochureNumber { get; set; }
        public string Title { get; set; }
        public CoverType CoverType { get; set; }
    }
}