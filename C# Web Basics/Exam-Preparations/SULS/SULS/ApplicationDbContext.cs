using Microsoft.EntityFrameworkCore;
using SULS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Submission> Submissions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PHQG6TO\\SQLEXPRESS;Database=SULS;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u => 
            {
                u.HasKey(x => x.Id);

                u.HasMany(x => x.Submissions)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
            });

            modelBuilder.Entity<Problem>(p =>
            {
                p.HasKey(x => x.Id);

                p.HasMany(x => x.Submissions)
                .WithOne(x => x.Problem)
                .HasForeignKey(x => x.ProblemId);
            });

            modelBuilder.Entity<Submission>(s =>
            {
                s.HasKey(x => x.Id);           
            });
        }
    }
}
