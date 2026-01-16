using Microsoft.EntityFrameworkCore;
using DynastyOfChampions.Foundation.Data.Persistence.Entities;

namespace DynastyOfChampions.Foundation.Data.Persistence.Context
{
	/// <summary>
	/// Primary EF Core DbContext for the Dynasty of Champions platform.
	/// Handles persistence for sports, leagues, hierarchy units, teams,
	/// players, seasons, rosters, and all historical records.
	/// </summary>
	public class DynastyDbContext : DbContext
	{
		#region DbSets
		
		public DbSet<Sport> Sports => Set<Sport>();
		public DbSet<League> Leagues => Set<League>();
		public DbSet<LeagueHistory> LeagueHistories => Set<LeagueHistory>();

		public DbSet<LeagueUnit> LeagueUnits => Set<LeagueUnit>();
		public DbSet<LeagueUnitHistory> LeagueUnitHistories => Set<LeagueUnitHistory>();

		public DbSet<Team> Teams => Set<Team>();
		public DbSet<TeamHistory> TeamHistories => Set<TeamHistory>();

		public DbSet<Player> Players => Set<Player>();
		public DbSet<PlayerHistory> PlayerHistories => Set<PlayerHistory>();

		public DbSet<Season> Seasons => Set<Season>();
		public DbSet<Roster> Rosters => Set<Roster>();
		public DbSet<RosterEntry> RosterEntries => Set<RosterEntry>();

		#endregion

		public DynastyDbContext(DbContextOptions<DynastyDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			#region SequentialGuidDefaults

			// Apply NEWSEQUENTIALID() to all Guid PKs named "Id"
			foreach (var entity in modelBuilder.Model.GetEntityTypes())
			{
				var id = entity.FindProperty("Id");
				if (id != null && id.ClrType == typeof(Guid))
				{
					id.SetDefaultValueSql("NEWSEQUENTIALID()");
				}
			}

			#endregion

			#region EntityConfigurations

			// Sport
			modelBuilder.Entity<Sport>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.Description)
					.HasMaxLength(500);

				// Sport -> League
				entity.HasMany(e => e.Leagues)
					.WithOne(l => l.Sport)
					.HasForeignKey(l => l.SportId)
					.OnDelete(DeleteBehavior.Cascade);
			});

			// League
			modelBuilder.Entity<League>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.SportId)
					.IsRequired();

				// League -> Sport
				entity.HasOne(e => e.Sport)
					.WithMany(s => s.Leagues)
					.HasForeignKey(e => e.SportId);

				// League -> LeagueHistory
				entity.HasMany(e => e.History)
					.WithOne(h => h.League)
					.HasForeignKey(h => h.LeagueId)
					.OnDelete(DeleteBehavior.Cascade);
			});

			// LeagueHistory
			modelBuilder.Entity<LeagueHistory>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.Abbreviation)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.Description)
					.HasMaxLength(500);
			});

			// LeagueUnit
			modelBuilder.Entity<LeagueUnit>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.LeagueId)
					.IsRequired();

				// LeagueUnit -> League
				entity.HasOne(e => e.League)
					.WithMany(l => l.LeagueUnits)
					.HasForeignKey(e => e.LeagueId);

				// LeagueUnit -> History
				entity.HasMany(e => e.History)
					.WithOne(h => h.LeagueUnit)
					.HasForeignKey(h => h.LeagueUnitId)
					.OnDelete(DeleteBehavior.Cascade);

				// Teams in this unit
				entity.HasMany(e => e.Teams)
					.WithOne(t => t.LeagueUnit)
					.HasForeignKey(t => t.LeagueUnitId);
			});

			// LeagueUnitHistory
			modelBuilder.Entity<LeagueUnitHistory>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.DisplayLabel)
					.HasMaxLength(50);

				// Historical parent relationship (self-reference)
				entity.HasOne<LeagueUnitHistory>()
					.WithMany()
					.HasForeignKey(e => e.ParentId)
					.OnDelete(DeleteBehavior.Restrict);
			});

			// Team
			modelBuilder.Entity<Team>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.LeagueUnitId)
					.IsRequired();

				// Team -> LeagueUnit
				entity.HasOne(e => e.LeagueUnit)
					.WithMany(u => u.Teams)
					.HasForeignKey(e => e.LeagueUnitId);

				// Team -> TeamHistory
				entity.HasMany(e => e.History)
					.WithOne(h => h.Team)
					.HasForeignKey(h => h.TeamId)
					.OnDelete(DeleteBehavior.Cascade);
			});

			// TeamHistory
			modelBuilder.Entity<TeamHistory>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.Abbreviation)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.Location)
					.IsRequired()
					.HasMaxLength(100);
			});

			// Player
			modelBuilder.Entity<Player>(entity =>
			{
				entity.HasKey(e => e.Id);

				// Player -> PlayerHistory
				entity.HasMany(e => e.History)
					.WithOne(h => h.Player)
					.HasForeignKey(h => h.PlayerId)
					.OnDelete(DeleteBehavior.Cascade);
			});

			// PlayerHistory
			modelBuilder.Entity<PlayerHistory>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.FirstName)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.LastName)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.Position)
					.HasMaxLength(10);
			});

			// Season
			modelBuilder.Entity<Season>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.LeagueId)
					.IsRequired();

				// Season -> League
				entity.HasOne(e => e.League)
					.WithMany(l => l.Seasons)
					.HasForeignKey(e => e.LeagueId);
			});

			// Roster
			modelBuilder.Entity<Roster>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.RosterType)
					.IsRequired()
					.HasMaxLength(50);

				// Roster -> Team
				entity.HasOne(e => e.Team)
					.WithMany(t => t.Rosters)
					.HasForeignKey(e => e.TeamId);

				// Roster -> Season
				entity.HasOne(e => e.Season)
					.WithMany(s => s.Rosters)
					.HasForeignKey(e => e.SeasonId);
			});

			// RosterEntry
			modelBuilder.Entity<RosterEntry>(entity =>
			{
				entity.HasKey(e => e.Id);

				// RosterEntry -> Roster
				entity.HasOne(e => e.Roster)
					.WithMany(r => r.Entries)
					.HasForeignKey(e => e.RosterId);

				// RosterEntry -> Player
				entity.HasOne(e => e.Player)
					.WithMany(p => p.RosterEntries)
					.HasForeignKey(e => e.PlayerId);
			});

			#endregion
		}
	}
}