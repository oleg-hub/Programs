using OnlineShop.Entities.Enums;

namespace OnlineShop.Entities
{
   public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public byte[] Picture { get; set; }
        public Category KindOfGoods { get; set; }
        public Brand Brand { get; set; }

    }
}
