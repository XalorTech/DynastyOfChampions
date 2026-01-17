using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the RosterPlayer entity for EF Core.
	/// </summary>
	public class RosterPlayerConfiguration : IEntityTypeConfiguration<RosterPlayer>
	{
		public void Configure(EntityTypeBuilder<RosterPlayer> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Date Player joined the roster
			entity.Property(e => e.StartDate)
				.IsRequired();

			// Notes
			entity.Property(e => e.Notes)
				.HasMaxLength(500);

			#endregion

			#region ForeignKeys

			// RosterPlayer -> Roster
			entity.Property(e => e.RosterId)
				.IsRequired();

			// RosterPlayer -> Player
			entity.Property(e => e.PlayerId)
				.IsRequired();

			// RosterPlayer -> Status
			entity.Property(e => e.StatusId);

			#endregion

			#region Relationships

			// RosterPlayer -> Roster
			entity.HasOne(e => e.Roster)
				.WithMany(r => r.Players)
				.HasForeignKey(e => e.RosterId);

			// RosterPlayer -> Player
			entity.HasOne(e => e.Player)
				.WithMany(p => p.RosterPlayers)
				.HasForeignKey(e => e.PlayerId);

			// RosterPlayer -> Status
			entity.HasOne(e => e.Status)
				.WithMany()
				.HasForeignKey(e => e.StatusId)
				.OnDelete(DeleteBehavior.SetNull);

			// RosterPlayer -> RosterPlayerPosition
			entity.HasMany(e => e.Positions)
				.WithOne(rpp => rpp.RosterPlayer)
				.HasForeignKey(rpp => rpp.RosterPlayerId)
				.OnDelete(DeleteBehavior.Cascade);

			#endregion
		}
	}
}