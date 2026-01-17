using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	public class SeasonConfiguration : IEntityTypeConfiguration<Season>
	{
		public void Configure(EntityTypeBuilder<Season> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region ForeignKeys

			// Season -> League
			entity.Property(e => e.LeagueId)
				.IsRequired();

			#endregion

			#region Relationships

			// Season -> League
			entity.HasOne(e => e.League)
				.WithMany(l => l.Seasons)
				.HasForeignKey(e => e.LeagueId);

			// Season -> Roster
			entity.HasMany(e => e.Rosters)
				.WithOne(r => r.Season)
				.HasForeignKey(r => r.SeasonId);

			#endregion
		}
	}
}