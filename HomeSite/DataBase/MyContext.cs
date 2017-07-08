using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HomeSite.Models;

namespace HomeSite.DataBase
{
    public class MyDataBase : DbContext
    {
        //public DbSet<Person> Persons { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MyDataBase>(null);
            modelBuilder.HasDefaultSchema("u0349926_admin");
            base.OnModelCreating(modelBuilder);
        }
    }
}