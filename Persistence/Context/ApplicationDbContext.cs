using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<City>().HasIndex(p => p.Ptt).IsUnique(true);
            modelBuilder.Entity<Employee>().HasIndex(p => p.SocialNumber).IsUnique(true);
            modelBuilder.Entity<User>().HasIndex(p => p.Password).IsUnique(true);
            modelBuilder.Entity<User>().HasIndex(p => p.Email).IsUnique(true);
            modelBuilder.Entity<User>().HasIndex(p => p.Phone).IsUnique(true);
            // modelBuilder.Entity<City>().Property(p => p.Name).HasColumnType("decimal(10, 2)");
            modelBuilder.Entity<User>().HasDiscriminator<string>("UserType").HasValue<Employee>("Employee").HasValue<Client>("Client");
            modelBuilder.Entity<User>().HasOne(u => u.City).WithMany();
            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }

      
    }
}
