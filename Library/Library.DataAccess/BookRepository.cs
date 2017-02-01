﻿using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
   public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(ApplicationContext context) : base (context)
        {
        }
    }
}
