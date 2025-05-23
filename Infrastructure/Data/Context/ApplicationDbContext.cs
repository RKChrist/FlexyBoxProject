using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Resturant> Resturants { get; set; }

        public DbSet<Images> Images { get; set; }

        public DbSet<Openings> Openings { get; set; }

        public DbSet<DaysOpen> Days { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Openings>()
                            .HasMany(o => o.Days)
                            .WithOne()
                            .HasForeignKey(d => d.OpeningsId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=flexybox;Trusted_Connection=True;MultipleActiveResultSets=true")
                          .UseSeeding((context, d) =>
                          {
                              
                              SeedData.Initialize((ApplicationDbContext)context);
                          });
        }
        
    }
}
