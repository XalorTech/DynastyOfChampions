using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	public class LeagueHistoryConfiguration : IEntityTypeConfiguration<LeagueHistory>
	{
		public void Configure(EntityTypeBuilder<LeagueHistory> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Official name of the league
			entity.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(100);

			// Abbreviated name of the league
			entity.Property(e => e.Abbreviation)
				.IsRequired()
				.HasMaxLength(20);

			// Brief description of the league
			entity.Property(e => e.Description)
				.HasMaxLength(500);

			#endregion

			#region ForeignKeys

			// LeagueHistory -> League
			entity.Property(e => e.LeagueId)
				.IsRequired();

			#endregion
		}
	}
}