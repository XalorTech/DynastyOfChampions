using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	public class LeagueUnitConfiguration : IEntityTypeConfiguration<LeagueUnit>
	{
		public void Configure(EntityTypeBuilder<LeagueUnit> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region ForeignKeys

			// LeagueUnit -> League
			entity.Property(e => e.LeagueId)
				.IsRequired();

			#endregion

			#region Relationships

			// LeagueUnit -> League
			entity.HasOne(e => e.League)
				.WithMany(l => l.LeagueUnits)
				.HasForeignKey(e => e.LeagueId);

			// LeagueUnit -> LeagueUnitHistory
			entity.HasMany(e => e.History)
				.WithOne(h => h.LeagueUnit)
				.HasForeignKey(h => h.LeagueUnitId)
				.OnDelete(DeleteBehavior.Cascade);

			// LeagueUnit -> Team
			entity.HasMany(e => e.Teams)
				.WithOne(t => t.LeagueUnit)
				.HasForeignKey(t => t.LeagueUnitId);

			#endregion
		}
	}
}