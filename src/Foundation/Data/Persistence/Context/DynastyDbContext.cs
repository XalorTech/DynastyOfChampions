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

		#region Person

		public DbSet<Person> Persons => Set<Person>();
		public DbSet<PersonHistory> PersonHistories => Set<PersonHistory>();
		public DbSet<PersonNickname> PersonNicknames => Set<PersonNickname>();

		#endregion

		#region Roles

		public DbSet<RoleType> RoleTypes => Set<RoleType>();
		public DbSet<Player> Players => Set<Player>();
		public DbSet<Coach> Coaches => Set<Coach>();

		#endregion

		#region Career

		public DbSet<CareerPhase> CareerPhases => Set<CareerPhase>();

		#endregion

		#region Rosters

		// Player Roster entities
		public DbSet<RosterPlayer> RosterPlayers => Set<RosterPlayer>();
		public DbSet<RosterPlayerPosition> RosterPlayerPositions => Set<RosterPlayerPosition>();

		// Coach Roster entities
		public DbSet<RosterCoach> RosterCoaches => Set<RosterCoach>();
		public DbSet<RosterCoachType> RosterCoachTypes => Set<RosterCoachType>();

		#endregion

		#region League Metadata

		public DbSet<CoachType> CoachTypes => Set<CoachType>();
		public DbSet<Position> Positions => Set<Position>();
		public DbSet<Status> Statuses => Set<Status>();

		#endregion

		#region Sports Structure

		public DbSet<Sport> Sports => Set<Sport>();
		public DbSet<League> Leagues => Set<League>();
		public DbSet<LeagueHistory> LeagueHistories => Set<LeagueHistory>();
		public DbSet<LeagueUnit> LeagueUnits => Set<LeagueUnit>();
		public DbSet<LeagueUnitHistory> LeagueUnitHistories => Set<LeagueUnitHistory>();
		public DbSet<Team> Teams => Set<Team>();
		public DbSet<TeamHistory> TeamHistories => Set<TeamHistory>();
		public DbSet<Season> Seasons => Set<Season>();
		public DbSet<Roster> Rosters => Set<Roster>();

		#endregion

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