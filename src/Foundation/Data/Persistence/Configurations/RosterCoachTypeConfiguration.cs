using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the RosterCoachType entity for EF Core.
	/// </summary>
	public class RosterCoachTypeConfiguration : IEntityTypeConfiguration<RosterCoachType>
	{
		public void Configure(EntityTypeBuilder<RosterCoachType> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region ForeignKeys

			// RosterCoachType -> RosterCoach
			entity.Property(e => e.RosterCoachId)
				.IsRequired();

			// RosterCoachType -> CoachType
			entity.Property(e => e.CoachTypeId)
				.IsRequired();

			#endregion

			#region Relationships

			// RosterCoachType -> RosterCoach
			entity.HasOne(e => e.RosterCoach)
				.WithMany(rc => rc.CoachTypes)
				.HasForeignKey(e => e.RosterCoachId);

			// RosterCoachType -> CoachType
			entity.HasOne(e => e.CoachType)
				.WithMany(ct => ct.RosterCoachTypes)
				.HasForeignKey(e => e.CoachTypeId);

			#endregion
		}
	}
}