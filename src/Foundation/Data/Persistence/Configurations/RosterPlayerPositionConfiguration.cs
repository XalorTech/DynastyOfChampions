using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the RosterPlayerPosition entity for EF Core.
	/// </summary>
	public class RosterPlayerPositionConfiguration : IEntityTypeConfiguration<RosterPlayerPosition>
	{
		public void Configure(EntityTypeBuilder<RosterPlayerPosition> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region ForeignKeys

			// RosterPlayerPosition -> RosterPlayer
			entity.Property(e => e.RosterPlayerId)
				.IsRequired();

			// RosterPlayerPosition -> Position
			entity.Property(e => e.PositionId)
				.IsRequired();

			#endregion

			#region Relationships

			// RosterPlayerPosition -> RosterPlayer
			entity.HasOne(e => e.RosterPlayer)
				.WithMany(rp => rp.Positions)
				.HasForeignKey(e => e.RosterPlayerId);

			// RosterPlayerPosition -> Position
			entity.HasOne(e => e.Position)
				.WithMany(p => p.RosterPlayerPositions)
				.HasForeignKey(e => e.PositionId);

			#endregion
		}
	}
}