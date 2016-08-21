using Online_Shop.Application.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Online_Shop.Application.DataAccessLayer
{
    public class ShopDAL:DbContext
    {       
       protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetail>().ToTable("UserData");
            modelBuilder.Entity<Notifications>().ToTable("Notifications");
           modelBuilder.Entity<Product>().ToTable("Product");
           modelBuilder.Entity<images>().ToTable("images");
           modelBuilder.Entity<Category>().ToTable("Category");
           modelBuilder.Entity<Subscribers>().ToTable("Subscribers");
           modelBuilder.Entity<Reviews>().ToTable("Reviews");
 	        base.OnModelCreating(modelBuilder);
        }
        public DbSet<UserDetail> Users { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<images> Images { get; set; }

        public DbSet<Cart> Cart { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Subscribers> Subscribers { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
    }
    }
