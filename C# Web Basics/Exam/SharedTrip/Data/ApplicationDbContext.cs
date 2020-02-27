namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<UserTrip> UserTrips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Trip>(t =>
            {
                t.HasKey(x => x.Id);
            });

            modelBuilder.Entity<UserTrip>(ut =>
            {
                ut.HasKey(x => new { x.UserId, x.TripId});

                ut.HasOne(x => x.User)
                .WithMany(x => x.UserTrips)
                .HasForeignKey(x => x.UserId);

                ut.HasOne(x => x.Trip)
                .WithMany(x => x.UserTrips)
                .HasForeignKey(x => x.TripId);
            });
        }
    }
}
