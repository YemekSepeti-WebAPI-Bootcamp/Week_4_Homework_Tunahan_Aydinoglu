using Microsoft.EntityFrameworkCore;
using Odev2.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev2.Data.Context
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
