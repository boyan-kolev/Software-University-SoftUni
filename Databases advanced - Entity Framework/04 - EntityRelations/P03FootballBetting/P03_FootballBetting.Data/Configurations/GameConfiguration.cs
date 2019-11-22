namespace P03_FootballBetting.Data.Configurations
{
    using P03_FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> game)
        {
            game.HasKey(g => g.GameId);

            game.HasMany(g => g.Bets)
                .WithOne(b => b.Game)
                .HasForeignKey(g => g.GameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
