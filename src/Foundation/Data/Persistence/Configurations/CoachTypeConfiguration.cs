using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the CoachType entity for EF Core.
	/// </summary>
	public class CoachTypeConfiguration : IEntityTypeConfiguration<CoachType>
	{
		public void Configure(EntityTypeBuilder<CoachType> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Name
			entity.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(100);

			// Abbreviation
			entity.Property(e => e.Abbreviation)
				.IsRequired()
				.HasMaxLength(20);

			// Description
			entity.Property(e => e.Description)
				.HasMaxLength(500);

			// Sort order for listing Coach Types
			entity.Property(e => e.SortOrder)
				.IsRequired();

			#endregion

			#region ForeignKeys

			// CoachType -> League
			entity.Property(e => e.LeagueId)
				.IsRequired();

			#endregion

			#region Relationships

			// CoachType -> League
			entity.HasOne(e => e.League)
				.WithMany(l => l.CoachTypes)
				.HasForeignKey(e => e.LeagueId);

			#endregion
		}
	}
}