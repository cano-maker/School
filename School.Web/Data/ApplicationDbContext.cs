using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Web.Models;



namespace School.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }



        public DbSet<Student> Students { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Neighborhood> Neighborhoods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Student>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<City>()
            .HasIndex(t => t.Name)
            .IsUnique();

            modelBuilder.Entity<Neighborhood>()
            .HasIndex(t => t.Name)
            .IsUnique();

        }
    }
}
