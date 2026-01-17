using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the Coach entity for EF Core.
	/// </summary>
	public class CoachConfiguration : IEntityTypeConfiguration<Coach>
	{
		public void Configure(EntityTypeBuilder<Coach> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region ForeignKeys

			// Coach -> Person
			entity.Property(e => e.PersonId)
				.IsRequired();

			// Coach -> League
			entity.Property(e => e.LeagueId)
				.IsRequired();

			#endregion

			#region Relationships

			// Coach -> Person
			entity.HasOne(e => e.Person)
				.WithMany(p => p.CoachRoles)
				.HasForeignKey(e => e.PersonId);

			// Coach -> League
			entity.HasOne(e => e.League)
				.WithMany(l => l.Coaches)
				.HasForeignKey(e => e.LeagueId);

			#endregion
		}
	}
}