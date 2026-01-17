using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the RoleType entity for EF Core.
	/// </summary>
	public class RoleTypeConfiguration : IEntityTypeConfiguration<RoleType>
	{
		public void Configure(EntityTypeBuilder<RoleType> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Role Name
			entity.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(100);

			// Role Description
			entity.Property(e => e.Description)
				.HasMaxLength(500);

			// Role Sort Order
			entity.Property(e => e.SortOrder)
				.IsRequired();

			#endregion

			#region ForeignKeys

			// RoleType -> Sport
			entity.Property(e => e.SportId);

			// RoleType -> League
			entity.Property(e => e.LeagueId);

			#endregion

			#region Relationships

			// RoleType -> Sport
			entity.HasOne(e => e.Sport)
				.WithMany(s => s.RoleTypes)
				.HasForeignKey(e => e.SportId);

			// RoleType -> League
			entity.HasOne(e => e.League)
				.WithMany(l => l.RoleTypes)
				.HasForeignKey(e => e.LeagueId);

			#endregion
		}
	}
}