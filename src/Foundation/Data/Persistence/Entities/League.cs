using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a league within a specific sport. The base model stores only
	/// stable identity and structural relationships. All time-variant attributes
	/// such as name or abbreviation are stored in <see cref="LeagueHistory"/>.
	/// </summary>
	public class League
	{
		#region Properties

		/// <summary>
		/// The unique identifier for the league.
		/// </summary>
		public Guid Id { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the sport to which this league belongs.
		/// </summary>
		public Guid SportId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Historical records describing time-variant attributes of this league.
		/// </summary>
		public ICollection<LeagueHistory> History { get; set; } = new List<LeagueHistory>();

		/// <summary>
		/// The parent sport associated with this league.
		/// </summary>
		public Sport Sport { get; set; } = null!;

		/// <summary>
		/// The hierarchical structural units associated with this league.
		/// </summary>
		public ICollection<LeagueUnit> LeagueUnits { get; set; } = new List<LeagueUnit>();

		/// <summary>
		/// The seasons associated with this league.
		/// </summary>
		public ICollection<Season> Seasons { get; set; } = new List<Season>();

		/// <summary>
		/// The collection of role types representing the types assigned
		/// to players and coaches in this league during the season.
		/// </summary>
		public ICollection<RoleType> RoleTypes { get; set; } = new List<RoleType>();

		/// <summary>
		/// The collection of roster coach entries representing the coaches assigned
		/// to this league during the season.
		/// </summary>
		public ICollection<RosterCoach> Coaches { get; set; } = new List<RosterCoach>();

		/// <summary>
		/// The collection of coach types representing the types assigned
		/// to coaches in this league during the season.
		/// </summary>
		public ICollection<CoachType> CoachTypes { get; set; } = new List<CoachType>();

		/// <summary>
		/// The collection of roster player entries representing the players assigned
		/// to this league during the season.
		/// </summary>
		public ICollection<RosterPlayer> Players { get; set; } = new List<RosterPlayer>();

		/// <summary>
		/// The collection of career phases representing the different stages
		/// of player careers within this league.
		/// </summary>
		public ICollection<CareerPhase> CareerPhases { get; set; } = new List<CareerPhase>();

		#endregion
	}
}