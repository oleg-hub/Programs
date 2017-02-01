using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class CoverRepository : BaseRepository<Cover>
    {
        public CoverRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
