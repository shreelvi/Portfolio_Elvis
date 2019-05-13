﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
        public MusicStoreContext() : base("MusicStoreContext")
        {
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
