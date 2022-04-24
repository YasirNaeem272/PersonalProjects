using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TashBlock.Models;

namespace TashBlock.Context
{
    public class AddDbContext:DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext>options):base(options)
        {

        }
        public DbSet<HeadLevel> task { get; set; }
        public DbSet<HeadLevel2> task2 { get; set; }
        public DbSet<HeadLevel3> task3 { get; set; }
        public DbSet<Category1> category { get; set; }
        public DbSet<Subcategory> subcategory { get; set; }
        public DbSet<Unitofmaterial> Unitofmaterial { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Supplier> supplier { get; set; }
        public DbSet<purchaseorder> purchaseorder { get; set; }
    }
}
