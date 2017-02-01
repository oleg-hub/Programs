using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class NewspaperRepository : BaseRepository<Newspaper>
    {
        public NewspaperRepository(ApplicationContext context) : base(context)
        {
        }
    }
}