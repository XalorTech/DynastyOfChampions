using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the TeamHistory entity for EF Core.
	/// </summary>
	public class TeamHistoryConfiguration : IEntityTypeConfiguration<TeamHistory>
	{
		public void Configure(EntityTypeBuilder<TeamHistory> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Official name of the team
			entity.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(100);

			// Abbreviated name of the team
			entity.Property(e => e.Abbreviation)
				.IsRequired()
				.HasMaxLength(20);

			// Organization that owns or operates the team
			entity.Property(e => e.Organization)
				.HasMaxLength(100);

			// City where the team is based
			entity.Property(e => e.City)
				.HasMaxLength(100);

			// Region where the team is based
			entity.Property(e => e.Region)
				.HasMaxLength(100);

			// Country where the team is based
			entity.Property(e => e.Country)
				.HasMaxLength(100);

			// Team Entry's start date
			entity.Property(e => e.StartDate)
				.IsRequired();

			#endregion

			#region ForeignKeys

			// TeamHistory -> Team
			entity.Property(e => e.TeamId)
				.IsRequired();

			// TeamHistory -> League
			entity.Property(e => e.LeagueId)
				.IsRequired();

			// TeamHistory -> LeagueUnit
			entity.Property(e => e.LeagueUnitId)
				.IsRequired();

			#endregion

			#region Relationships

			// TeamHistory -> Team
			entity.HasOne(e => e.Team)
				.WithMany(t => t.History)
				.HasForeignKey(e => e.TeamId);

			// TeamHistory -> League
			entity.HasOne(e => e.League)
				.WithMany(l => l.TeamHistories)
				.HasForeignKey(e => e.TeamId);

			// TeamHistory -> LeagueUnit
			entity.HasOne(e => e.LeagueUnit)
				.WithMany(lu => lu.TeamHistories)
				.HasForeignKey(e => e.LeagueUnitId);

			#endregion
		}
	}
}