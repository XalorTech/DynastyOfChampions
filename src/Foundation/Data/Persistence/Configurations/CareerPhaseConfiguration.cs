using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the CareerPhase entity for EF Core.
	/// </summary>
	public class CareerPhaseConfiguration : IEntityTypeConfiguration<CareerPhase>
	{
		public void Configure(EntityTypeBuilder<CareerPhase> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Date Career Phase began
			entity.Property(e => e.StartDate)
				.IsRequired();

			// Reason Career Phase ended
			entity.Property(e => e.EndReason)
				.HasMaxLength(200);

			#endregion

			#region ForeignKeys

			// CareerPhase -> Person
			entity.Property(e => e.PersonId)
				.IsRequired();

			// CareerPhase -> RoleType
			entity.Property(e => e.RoleTypeId)
				.IsRequired();

			// CareerPhase -> League
			entity.Property(e => e.LeagueId)
				.IsRequired();

			// CareerPhase -> Sport
			entity.Property(e => e.SportId)
				.IsRequired();

			#endregion

			#region Relationships

			// CareerPhase -> Person
			entity.HasOne(e => e.Person)
				.WithMany(p => p.CareerPhases)
				.HasForeignKey(e => e.PersonId);

			// CareerPhase -> RoleType
			entity.HasOne(e => e.RoleType)
				.WithMany(r => r.CareerPhases)
				.HasForeignKey(e => e.RoleTypeId);

			// CareerPhase -> League
			entity.HasOne(e => e.League)
				.WithMany(l => l.CareerPhases)
				.HasForeignKey(e => e.LeagueId);

			// CareerPhase -> Sport
			entity.HasOne(e => e.Sport)
				.WithMany(s => s.CareerPhases)
				.HasForeignKey(e => e.SportId);

			#endregion
		}
	}
}