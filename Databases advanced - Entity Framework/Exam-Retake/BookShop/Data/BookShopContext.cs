﻿namespace BookShop.Data
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookShopContext : DbContext
    {
        public BookShopContext() { }

        public BookShopContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorBook> AuthorsBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(a =>
            {
                a.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey(x => x.Id);
            });

            modelBuilder.Entity<AuthorBook>(ab =>
            {
                ab.HasKey(x => new { x.AuthorId, x.BookId});

                ab.HasOne(x => x.Author)
                .WithMany(x => x.AuthorsBooks)
                .HasForeignKey(x => x.AuthorId);

                ab.HasOne(x => x.Book)
                .WithMany(x => x.AuthorsBooks)
                .HasForeignKey(x => x.BookId);
            });
        }
    }
}