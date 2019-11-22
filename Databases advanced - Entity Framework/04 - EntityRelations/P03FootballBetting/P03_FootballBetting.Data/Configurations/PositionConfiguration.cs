namespace P03_FootballBetting.Data.Configurations
{
    using P03_FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> position)
        {
            position.HasKey(p => p.PositionId);

            position.HasMany(po => po.Players)
                .WithOne(pl => pl.Position)
                .HasForeignKey(po => po.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
