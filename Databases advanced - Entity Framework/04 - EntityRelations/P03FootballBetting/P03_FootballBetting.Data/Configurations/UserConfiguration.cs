namespace P03_FootballBetting.Data.Configurations
{
    using P03_FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.HasKey(u => u.UserId);

            user.HasMany(u => u.Bets)
                .WithOne(b => b.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
