using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	public class TeamConfiguration : IEntityTypeConfiguration<Team>
	{
		public void Configure(EntityTypeBuilder<Team> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region ForeignKeys

			// Team -> LeagueUnit
			entity.Property(e => e.LeagueUnitId)
				.IsRequired();

			#endregion

			#region Relationships

			// Team -> LeagueUnit
			entity.HasOne(e => e.LeagueUnit)
				.WithMany(u => u.Teams)
				.HasForeignKey(e => e.LeagueUnitId);

			// Team -> TeamHistory
			entity.HasMany(e => e.History)
				.WithOne(h => h.Team)
				.HasForeignKey(h => h.TeamId)
				.OnDelete(DeleteBehavior.Cascade);

			// Team -> Roster
			entity.HasMany(e => e.Rosters)
				.WithOne(r => r.Team)
				.HasForeignKey(r => r.TeamId);

			#endregion
		}
	}
}