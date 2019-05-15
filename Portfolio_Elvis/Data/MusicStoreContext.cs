using Microsoft.EntityFrameworkCore;
using Portfolio_Elvis.Models.MusicStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Elvis.Models
{
    /// <summary>
    /// Created by: Elvis
    /// This class will represent the Entity Framework database context, 
    /// and will handle our create, read, update, and delete operations for us.
    /// https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-4
    /// </summary>
    public class MusicStoreContext: DbContext
    {
        public MusicStoreContext(DbContextOptions<MusicStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        //// override the default behavior by specifying singular table names in the DbContext
        //// https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-2.2
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Album>().ToTable("Album");
        //    modelBuilder.Entity<Artist>().ToTable("Artist");
        //    modelBuilder.Entity<Genre>().ToTable("Genre");
        //    modelBuilder.Entity<Cart>().ToTable("Cart");
        //    modelBuilder.Entity<Order>().ToTable("Order");
        //    modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");

        //}
    }
}
