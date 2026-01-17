using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the Status entity for EF Core.
	/// </summary>
	public class StatusConfiguration : IEntityTypeConfiguration<Status>
	{
		public void Configure(EntityTypeBuilder<Status> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Status name
			entity.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(100);

			// Status abbreviation
			entity.Property(e => e.Abbreviation)
				.IsRequired()
				.HasMaxLength(20);

			// Status description
			entity.Property(e => e.Description)
				.HasMaxLength(500);

			// Status sort order
			entity.Property(e => e.SortOrder)
				.IsRequired();

			#endregion

			#region ForeignKeys

			// Status -> League
			entity.Property(e => e.LeagueId)
				.IsRequired();

			#endregion

			#region Relationships

			// Status -> League
			entity.HasOne(e => e.League)
				.WithMany(l => l.Statuses)
				.HasForeignKey(e => e.LeagueId);

			#endregion
		}
	}
}