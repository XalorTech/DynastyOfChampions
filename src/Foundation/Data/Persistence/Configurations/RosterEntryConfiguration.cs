using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the RosterEntry entity for EF Core.
	/// </summary>
	public class RosterEntryConfiguration : IEntityTypeConfiguration<RosterEntry>
	{
		public void Configure(EntityTypeBuilder<RosterEntry> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Roster Entry's start date
			entity.Property(e => e.StartDate)
				.IsRequired();

			// Roster Entry's notes
			entity.Property(e => e.Notes)
				.HasMaxLength(500);

			#endregion

			#region ForeignKeys

			// RosterEntry -> Roster
			entity.Property(e => e.RosterId)
				.IsRequired();

			// RosterEntry -> Player
			entity.Property(e => e.PlayerId)
				.IsRequired();

			#endregion

			#region Relationships

			// RosterEntry -> Roster
			entity.HasOne(e => e.Roster)
				.WithMany(r => r.Entries)
				.HasForeignKey(e => e.RosterId);

			// RosterEntry -> Player
			entity.HasOne(e => e.Player)
				.WithMany(p => p.RosterEntries)
				.HasForeignKey(e => e.PlayerId);

			// RosterEntry -> Status
			entity.HasOne(e => e.Status)
				.WithMany()
				.HasForeignKey(e => e.StatusId)
				.OnDelete(DeleteBehavior.SetNull);

			// RosterEntry -> Positions
			entity.HasMany(e => e.Positions)
				.WithOne(rep => rep.RosterEntry)
				.HasForeignKey(rep => rep.RosterEntryId)
				.OnDelete(DeleteBehavior.Cascade);
			#endregion
		}
	}
}