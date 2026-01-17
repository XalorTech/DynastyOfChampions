using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the RosterEntryPosition entity for EF Core.
	/// </summary>
	public class RosterEntryPositionConfiguration : IEntityTypeConfiguration<RosterEntryPosition>
	{
		public void Configure(EntityTypeBuilder<RosterEntryPosition> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region ForeignKeys

			// RosterEntryPosition -> RosterEntry
			entity.Property(e => e.RosterEntryId)
				.IsRequired();

			// RosterEntryPosition -> Position
			entity.Property(e => e.PositionId)
				.IsRequired();

			#endregion

			#region Relationships

			// RosterEntryPosition -> RosterEntry
			entity.HasOne(e => e.RosterEntry)
				.WithMany(re => re.Positions)
				.HasForeignKey(e => e.RosterEntryId);

			// RosterEntryPosition -> Position
			entity.HasOne(e => e.Position)
				.WithMany(p => p.RosterEntryPositions)
				.HasForeignKey(e => e.PositionId);

			#endregion
		}
	}
}