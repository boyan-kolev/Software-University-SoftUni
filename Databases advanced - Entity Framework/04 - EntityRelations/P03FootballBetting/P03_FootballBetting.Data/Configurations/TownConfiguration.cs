namespace P03_FootballBetting.Data.Configurations
{
    using P03_FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> town)
        {
            town.HasKey(t => t.TownId);

            town.HasMany(to => to.Teams)
                .WithOne(te => te.Town)
                .HasForeignKey(to => to.TownId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
