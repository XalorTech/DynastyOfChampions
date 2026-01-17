using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynastyOfChampions.Foundation.Data.Persistence.Configurations
{
	public class SportConfiguration : IEntityTypeConfiguration<Sport>
	{
		public void Configure(EntityTypeBuilder<Sport> entity)
		{
			#region PrimaryKey

			entity.HasKey(e => e.Id);

			entity.Property(e => e.Id)
				.HasDefaultValueSql("NEWSEQUENTIALID()");

			#endregion

			#region Properties

			// Official name of sport (i.e. Football, Basketball)
			entity.Property(e => e.Name)
				.IsRequired()
				.HasMaxLength(100);

			// Brief description of the sport
			entity.Property(e => e.Description)
				.HasMaxLength(500);

			#endregion

			#region Relationships

			// Sport -> League
			entity.HasMany(e => e.Leagues)
				.WithOne(l => l.Sport)
				.HasForeignKey(l => l.SportId)
				.OnDelete(DeleteBehavior.Cascade);

			#endregion
		}
	}
}