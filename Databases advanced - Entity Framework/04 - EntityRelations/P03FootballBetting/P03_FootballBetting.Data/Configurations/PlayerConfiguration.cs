namespace P03_FootballBetting.Data.Configurations
{
    using P03_FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> player)
        {
            player.HasKey(p => p.PlayerId);
        }
    }
}
