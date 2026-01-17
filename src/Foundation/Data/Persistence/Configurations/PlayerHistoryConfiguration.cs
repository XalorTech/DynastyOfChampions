using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	/// <summary>
	/// Configures the PlayerHistory entity for EF Core.
	/// </summary>
	public class PlayerHistoryConfiguration : IEntityTypeConfiguration<PlayerHistory>
	{
		public void Configure(EntityTypeBuilder<PlayerHistory> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Player's given names
			entity.Property(e => e.GivenNames)
				.IsRequired()
				.HasMaxLength(100);

			// Player's surname
			entity.Property(e => e.Surname)
				.IsRequired()
				.HasMaxLength(100);

			// Player's suffix
			entity.Property(e => e.Suffix)
				.HasMaxLength(20);

			// Player's nickname
			entity.Property(e => e.Nickname)
				.HasMaxLength(100);

			// Player Entry's start date
			entity.Property(e => e.StartDate)
				.IsRequired();

			#endregion

			#region ForeignKeys

			// PlayerHistory -> Player
			entity.Property(e => e.PlayerId)
				.IsRequired();

			#endregion

			#region Relationships

			// PlayerHistory -> Player
			entity.HasOne(e => e.Player)
				.WithMany(p => p.History)
				.HasForeignKey(e => e.PlayerId);

			#endregion
		}
	}
}