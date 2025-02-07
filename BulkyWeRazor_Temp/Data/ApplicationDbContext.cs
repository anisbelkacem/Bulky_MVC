﻿using BulkyWeRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeRazor_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Category_Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Category_Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Category_Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }


    }
}
