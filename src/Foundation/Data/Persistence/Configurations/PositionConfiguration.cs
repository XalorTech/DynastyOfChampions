using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the Position entity for EF Core.
	/// </summary>
	public class PositionConfiguration : IEntityTypeConfiguration<Position>
	{
		public void Configure(EntityTypeBuilder<Position> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Position name
			entity.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(100);

			// Position abbreviation
			entity.Property(e => e.Abbreviation)
				.IsRequired()
				.HasMaxLength(20);

			// Position description
			entity.Property(e => e.Description)
				.HasMaxLength(500);

			#endregion

			#region ForeignKeys

			// Position -> League
			entity.Property(e => e.LeagueId)
				.IsRequired();

			#endregion

			#region Relationships

			// Position -> League
			entity.HasOne(e => e.League)
				.WithMany(l => l.Positions)
				.HasForeignKey(e => e.LeagueId);

			// Position -> Parent
			entity.HasOne(e => e.Parent)
				.WithMany(p => p.Children)
				.HasForeignKey(e => e.ParentId)
				.OnDelete(DeleteBehavior.Restrict);

			// Position -> RosterPlayerPositions
			entity.HasMany(e => e.RosterPlayerPositions)
				.WithOne(rpp => rpp.Position)
				.HasForeignKey(rpp => rpp.PositionId);

			#endregion
		}
	}
}