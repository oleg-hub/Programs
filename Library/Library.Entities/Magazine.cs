using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Entities
{
   public class Magazine : BaseEntity
    {
        public string Title { get; set; }
        public string MagazineNumber { get; set; }

        public virtual ICollection<Cover> Covers { get; set; }
        public Magazine()
        {
            Covers = new List<Cover>();
        }
    }
}