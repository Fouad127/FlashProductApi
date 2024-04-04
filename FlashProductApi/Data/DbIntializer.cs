using FlashProductApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashProductApi.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                  Id = 1,
                  Name = "Cars"
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 2,
                    Name = "Mobile"
                }
            );

            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   Id = 3,
                   Name = "House"
               }
           );
        }
    }
}
