using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.enums
{
    public enum CoverType
    {
        [Display(Name = "Without Cover")]
        No,
        Hardback,
        Paperback
    }
}
