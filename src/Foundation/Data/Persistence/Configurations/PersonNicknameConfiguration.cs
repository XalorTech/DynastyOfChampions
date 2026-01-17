using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the PersonNickname entity for EF Core.
	/// </summary>
	public class PersonNicknameConfiguration : IEntityTypeConfiguration<PersonNickname>
	{
		public void Configure(EntityTypeBuilder<PersonNickname> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Nickname
			entity.Property(e => e.Nickname)
				.IsRequired()
				.HasMaxLength(100);

			#endregion

			#region ForeignKeys

			// PersonNickname -> PersonHistory
			entity.Property(e => e.PersonHistoryId)
				.IsRequired();

			#endregion

			#region Relationships

			// PersonNickname -> PersonHistory
			entity.HasOne(e => e.PersonHistory)
				.WithMany(ph => ph.Nicknames)
				.HasForeignKey(e => e.PersonHistoryId);

			#endregion
		}
	}
}