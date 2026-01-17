using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the TeamHistory entity for EF Core.
	/// </summary>
	public class TeamHistoryConfiguration : IEntityTypeConfiguration<TeamHistory>
	{
		public void Configure(EntityTypeBuilder<TeamHistory> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Official name of the team
			entity.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(100);

			// Abbreviated name of the team
			entity.Property(e => e.Abbreviation)
				.IsRequired()
				.HasMaxLength(20);

			// City where the team is based
			entity.Property(e => e.City)
				.HasMaxLength(100);

			// Region where the team is based
			entity.Property(e => e.Region)
				.HasMaxLength(100);

			// Country where the team is based
			entity.Property(e => e.Country)
				.HasMaxLength(100);

			// Display location of the team
			entity.Property(e => e.DisplayLocation)
				.HasMaxLength(100);

			// Short location of the team
			entity.Property(e => e.ShortLocation)
				.HasMaxLength(20);

			// Team Entry's start date
			entity.Property(e => e.StartDate)
				.IsRequired();

			#endregion

			#region ForeignKeys

			// TeamHistory -> Team
			entity.Property(e => e.TeamId)
				.IsRequired();

			#endregion

			#region Relationships

			// TeamHistory -> Team
			entity.HasOne(e => e.Team)
				.WithMany(t => t.History)
				.HasForeignKey(e => e.TeamId);

			#endregion
		}
	}
}