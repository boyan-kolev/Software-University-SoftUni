namespace P03_SalesDatabase.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
        {

        }

        public SalesContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureProductEntity(modelBuilder);

            ConfigureCustomerEntity(modelBuilder);

            ConfigureStoreEntity(modelBuilder);

            ConfigureSaleEntity(modelBuilder);

        }

        private void ConfigureSaleEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasKey(s => s.SaleId);

            modelBuilder.Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("GETDATE()");
        }

        private void ConfigureStoreEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasKey(s => s.StoreId);

            modelBuilder.Entity<Store>()
                .Property(s => s.Name)
                .HasMaxLength(80)
                .IsUnicode();

            modelBuilder.Entity<Store>()
                .HasMany(s => s.Sales)
                .WithOne(s => s.Store);
        }

        private void ConfigureCustomerEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer);
        }

        private void ConfigureProductEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Sales)
                .WithOne(s => s.Product);

        }
    }
}
