using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Entities
{
   public class CartInSoldProduct : BaseEntity
    {
        public virtual List<string> CartId { get; set; }
        public virtual string SoldProductId { get; set; }
    }
}
