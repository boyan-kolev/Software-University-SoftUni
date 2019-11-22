namespace P03_FootballBetting.Data.Configurations
{
    using P03_FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> team)
        {
            team.HasKey(t => t.TeamId);

            team.HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            team.HasMany(t => t.HomeGames)
                .WithOne(hg => hg.HomeTeam)
                .HasForeignKey(t => t.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            team.HasMany(t => t.AwayGames)
                .WithOne(hg => hg.AwayTeam)
                .HasForeignKey(t => t.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
