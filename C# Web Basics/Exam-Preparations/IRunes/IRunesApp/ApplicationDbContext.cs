using IRunesApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunesApp
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PHQG6TO\\SQLEXPRESS;Database=IRunesApp;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u => 
            {
                u.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Track>(t =>
            {
                t.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Album>(a =>
            {
                a.HasKey(x => x.Id);

                a.HasMany(x => x.Tracks)
                .WithOne(x => x.Album)
                .HasForeignKey(x => x.AlbumId);
            });
        }
    }
}
