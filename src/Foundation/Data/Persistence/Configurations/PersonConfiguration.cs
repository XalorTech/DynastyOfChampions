using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the Person entity for EF Core.
	/// </summary>
	public class PersonConfiguration : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// City of Birth
			entity.Property(e => e.BirthCity)
				.HasMaxLength(100);

			// Region of Birth
			entity.Property(e => e.BirthRegion)
				.HasMaxLength(100);

			// Country of Birth
			entity.Property(e => e.BirthCountry)
				.HasMaxLength(100);

			// City of Death
			entity.Property(e => e.DeathCity)
				.HasMaxLength(100);

			// Region of Death
			entity.Property(e => e.DeathRegion)
				.HasMaxLength(100);

			// Country of Death
			entity.Property(e => e.DeathCountry)
				.HasMaxLength(100);

			// Active Nickname
			entity.Property(e => e.ActiveNickname)
				.HasMaxLength(100);

			// Display Name
			entity.Property(e => e.DisplayName)
				.HasMaxLength(150);

			#endregion
		}
	}
}