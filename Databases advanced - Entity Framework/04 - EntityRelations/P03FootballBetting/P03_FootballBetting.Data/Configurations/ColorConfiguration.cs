namespace P03_FootballBetting.Data.Configurations
{
    using P03_FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> color)
        {
            color.HasKey(c => c.ColorId);

            color.HasMany(c => c.PrimaryKitTeams)
                .WithOne(t => t.PrimaryKitColor)
                .HasForeignKey(c => c.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            color.HasMany(c => c.SecondaryKitTeams)
                .WithOne(t => t.SecondaryKitColor)
                .HasForeignKey(c => c.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
