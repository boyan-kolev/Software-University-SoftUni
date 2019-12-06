namespace Cinema.Data
{
    using Cinema.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CinemaContext : DbContext
    {
        public CinemaContext()  { }

        public CinemaContext(DbContextOptions options)
            : base(options)   { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Projection> Projections { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Seat> Seats { get; set; }

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
            modelBuilder.Entity<Movie>(m =>
            {
                m.HasKey(x => x.Id);

                m.HasMany(x => x.Projections)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);

                m.Property(x => x.Genre)
                .IsRequired();

                m.Property(x => x.Duration)
                .IsRequired();
            });

            modelBuilder.Entity<Hall>(h =>
            {
                h.HasKey(x => x.Id);

                h.HasMany(x => x.Projections)
                .WithOne(x => x.Hall)
                .HasForeignKey(x => x.HallId);

                h.HasMany(x => x.Seats)
                .WithOne(x => x.Hall)
                .HasForeignKey(x => x.HallId);
            });

            modelBuilder.Entity<Projection>(p =>
            {
                p.HasKey(x => x.Id);

                p.Property(x => x.MovieId)
                .IsRequired();

                p.Property(x => x.HallId)
                .IsRequired();

                p.Property(x => x.DateTime)
                .IsRequired();

                p.HasMany(x => x.Tickets)
                .WithOne(x => x.Projection)
                .HasForeignKey(x => x.ProjectionId);
            });

            modelBuilder.Entity<Customer>(c =>
            {
                c.HasKey(x => x.Id);

                c.HasMany(x => x.Tickets)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);
            });

            modelBuilder.Entity<Ticket>(t =>
            {
                t.HasKey(x => x.Id);

                t.Property(x => x.CustomerId)
                .IsRequired();

                t.Property(x => x.ProjectionId)
                .IsRequired();
            });

            modelBuilder.Entity<Seat>(s =>
            {
                s.HasKey(x => x.Id);

                s.Property(x => x.HallId)
                .IsRequired();
            });
        }
    }
}