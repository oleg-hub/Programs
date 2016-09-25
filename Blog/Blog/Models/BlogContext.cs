﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Blog.Models
{
    public class BlogContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
    }
}