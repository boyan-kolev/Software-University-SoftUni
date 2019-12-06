namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<SongPerformer> SongsPerformers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Writer> Writers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Song>(s =>
            {
                s.HasKey(x => x.Id);

                

            });

            builder.Entity<Album>(a =>
            {
                a.HasKey(x => x.Id);

                a.HasMany(x => x.Songs)
                .WithOne(x => x.Album)
                .HasForeignKey(x => x.AlbumId);
            });

            builder.Entity<Performer>(p =>
            {
                p.HasKey(x => x.Id);
                
            });

            builder.Entity<Producer>(pr =>
            {
                pr.HasKey(x => x.Id);

                pr.HasMany(x => x.Albums)
                .WithOne(x => x.Producer)
                .HasForeignKey(x => x.ProducerId);
            });

            builder.Entity<Writer>(w =>
            {
                w.HasKey(x => x.Id);

                w.HasMany(x => x.Songs)
                .WithOne(x => x.Writer)
                .HasForeignKey(x => x.WriterId);
            });

            builder.Entity<SongPerformer>(sp =>
            {
                sp.HasKey(x => new { x.PerformerId, x.SongId});

                sp.HasOne(x => x.Song)
                .WithMany(x => x.SongPerformers)
                .HasForeignKey(x => x.SongId);

                sp.HasOne(x => x.Performer)
                .WithMany(x => x.PerformerSongs)
                .HasForeignKey(x => x.PerformerId);

            });
        }
    }
}
