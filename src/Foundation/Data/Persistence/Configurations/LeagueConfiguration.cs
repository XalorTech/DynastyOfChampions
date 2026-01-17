using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	public class LeagueConfiguration : IEntityTypeConfiguration<League>
	{
		public void Configure(EntityTypeBuilder<League> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region ForeignKeys

			// League -> Sport
			entity.Property(e => e.SportId)
				.IsRequired();

			#endregion

			#region Relationships

			// League -> Sport
			entity.HasOne(e => e.Sport)
				.WithMany(s => s.Leagues)
				.HasForeignKey(e => e.SportId);

			// League -> LeagueHistory
			entity.HasMany(e => e.History)
				.WithOne(h => h.League)
				.HasForeignKey(h => h.LeagueId)
				.OnDelete(DeleteBehavior.Cascade);

			// League -> LeagueUnit
			entity.HasMany(e => e.LeagueUnits)
				.WithOne(u => u.League)
				.HasForeignKey(u => u.LeagueId);

			// League -> Season
			entity.HasMany(e => e.Seasons)
				.WithOne(s => s.League)
				.HasForeignKey(s => s.LeagueId);

			#endregion
		}
	}
}