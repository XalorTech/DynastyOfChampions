using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the PersonHistory entity for EF Core.
	/// </summary>
	public class PersonHistoryConfiguration : IEntityTypeConfiguration<PersonHistory>
	{
		public void Configure(EntityTypeBuilder<PersonHistory> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Given Names
			entity.Property(e => e.GivenNames)
				.IsRequired()
				.HasMaxLength(100);

			// Surname
			entity.Property(e => e.Surname)
				.IsRequired()
				.HasMaxLength(100);

			// Suffix
			entity.Property(e => e.Suffix)
				.HasMaxLength(20);

			// Date record begins official use
			entity.Property(e => e.StartDate)
				.IsRequired();

			#endregion

			#region ForeignKeys

			// PersonHistory -> Person
			entity.Property(e => e.PersonId)
				.IsRequired();

			#endregion

			#region Relationships

			// PersonHistory -> Person
			entity.HasOne(e => e.Person)
				.WithMany(p => p.History)
				.HasForeignKey(e => e.PersonId);

			#endregion
		}
	}
}