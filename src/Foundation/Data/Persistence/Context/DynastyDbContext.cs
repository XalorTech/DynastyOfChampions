using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

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

		public DbSet<Position> Positions => Set<Position>();
		public DbSet<Status> Statuses => Set<Status>();

		public DbSet<Season> Seasons => Set<Season>();
		public DbSet<Roster> Rosters => Set<Roster>();
		public DbSet<RosterEntry> RosterEntries => Set<RosterEntry>();
		public DbSet<RosterEntryPosition> RosterEntryPositions => Set<RosterEntryPosition>();


		#endregion

		public DynastyDbContext(DbContextOptions<DynastyDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Automatically apply all IEntityTypeConfiguration<T> classes
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(DynastyDbContext).Assembly);
		}
	}
}