using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	public class LeagueUnitHistoryConfiguration : IEntityTypeConfiguration<LeagueUnitHistory>
	{
		public void Configure(EntityTypeBuilder<LeagueUnitHistory> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Official name of the league unit
			entity.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(100);

			// Display label for the league unit (i.e. Conference, Division, Sub-Division, etc.)
			entity.Property(e => e.DisplayLabel)
				.HasMaxLength(50);

			#endregion

			#region Relationships

			// Historical parent relationship (self-reference)
			entity.HasOne<LeagueUnitHistory>()
				.WithMany()
				.HasForeignKey(e => e.ParentId)
				.OnDelete(DeleteBehavior.Restrict);

			#endregion
		}
	}
}