using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	public class PlayerConfiguration : IEntityTypeConfiguration<Player>
	{
		public void Configure(EntityTypeBuilder<Player> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Relationships

			// Player -> PlayerHistory
			entity.HasMany(e => e.History)
				.WithOne(h => h.Player)
				.HasForeignKey(h => h.PlayerId)
				.OnDelete(DeleteBehavior.Cascade);

			// Player -> RosterEntry
			entity.HasMany(e => e.RosterEntries)
				.WithOne(r => r.Player)
				.HasForeignKey(r => r.PlayerId);

			#endregion
		}
	}
}