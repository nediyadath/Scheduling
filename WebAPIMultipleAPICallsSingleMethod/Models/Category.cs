using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMultipleAPICallsSingleMethod.Models
{
    public class EcomCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string photoPath { get; set; }
    }
    public class Food
    {
        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey("categ")]
        public int categID { get; set; }
        public EcomCategory categ { get; set; }
        public string desc { get; set; }
        public string photoPath { get; set; }
        public bool check { get; set; }
    }

    public class CateringContext: DbContext
    {
        public CateringContext(DbContextOptions<CateringContext> options): base(options)
        {

        }
        public DbSet<EcomCategory> EcomCategories { get; set; }
        public DbSet<Food> foods { get; set; }
    }
}
