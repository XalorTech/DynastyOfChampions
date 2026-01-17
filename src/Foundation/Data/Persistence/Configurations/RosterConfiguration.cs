using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	public class RosterConfiguration : IEntityTypeConfiguration<Roster>
	{
		public void Configure(EntityTypeBuilder<Roster> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Roster type (e.g., active, inactive, injured reserved)
			entity.Property(e => e.RosterType)
				.IsRequired()
				.HasMaxLength(50);

			#endregion

			#region Relationships

			// Roster -> Team
			entity.HasOne(e => e.Team)
				.WithMany(t => t.Rosters)
				.HasForeignKey(e => e.TeamId);

			// Roster -> Season
			entity.HasOne(e => e.Season)
				.WithMany(s => s.Rosters)
				.HasForeignKey(e => e.SeasonId);

			// Roster -> RosterEntry
			entity.HasMany(e => e.Entries)
				.WithOne(e => e.Roster)
				.HasForeignKey(e => e.RosterId);

			#endregion
		}
	}
}