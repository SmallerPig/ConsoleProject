using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ConsoleProject.Models
{
    public class WXSSKDbContext : DbContext
    {
        public WXSSKDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<WXSSKDbContext>(null);

        }

        public DbSet<Demo> Demo { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //取消默认复数表名的设置
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }
    }
}