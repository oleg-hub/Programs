using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
   public class Newspaper : BaseEntity
    {
        public string Title { get; set; }
        public int QuantityOfArticles { get; set; }
        public string ChiefEditor { get; set; }

    }
}
