using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the RosterCoach entity for EF Core.
	/// </summary>
	public class RosterCoachConfiguration : IEntityTypeConfiguration<RosterCoach>
	{
		public void Configure(EntityTypeBuilder<RosterCoach> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Date Coach joined the roster
			entity.Property(e => e.StartDate)
				.IsRequired();

			// Notes
			entity.Property(e => e.Notes)
				.HasMaxLength(500);

			#endregion

			#region ForeignKeys

			// RosterCoach -> Roster
			entity.Property(e => e.RosterId)
				.IsRequired();

			// RosterCoach -> Coach
			entity.Property(e => e.CoachId)
				.IsRequired();

			#endregion

			#region Relationships

			// RosterCoach -> Roster
			entity.HasOne(e => e.Roster)
				.WithMany(r => r.Coaches)
				.HasForeignKey(e => e.RosterId);

			// RosterCoach -> Coach
			entity.HasOne(e => e.Coach)
				.WithMany(c => c.RosterCoaches)
				.HasForeignKey(e => e.CoachId);

			// RosterCoach -> RosterCoachType
			entity.HasMany(e => e.CoachTypes)
				.WithOne(rct => rct.RosterCoach)
				.HasForeignKey(rct => rct.RosterCoachId)
				.OnDelete(DeleteBehavior.Cascade);

			#endregion
		}
	}
}