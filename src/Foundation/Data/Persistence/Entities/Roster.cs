using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a team's roster for a specific season. The base model stores only
	/// structural relationships and roster type. Individual player assignments and
	/// historical membership details are stored in <see cref="RosterEntry"/>.
	/// </summary>
	public class Roster
	{
		#region Properties

		/// <summary>
		/// The unique identifier for the roster.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The type of roster (e.g., "Active", "PracticeSquad", "InjuredReserve", "FreeAgent").
		/// </summary>
		public string RosterType { get; set; } = "Active";

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the team associated with this roster.
		/// </summary>
		public Guid TeamId { get; set; }

		/// <summary>
		/// The identifier of the season associated with this roster.
		/// </summary>
		public Guid SeasonId { get; set; }

		#endregion
		
		#region Navigation Properties

		/// <summary>
		/// The team associated with this roster.
		/// </summary>
		public Team Team { get; set; } = null!;

		/// <summary>
		/// The season associated with this roster.
		/// </summary>
		public Season Season { get; set; } = null!;

		/// <summary>
		/// The collection of roster coach entries representing the coaches assigned
		/// to this roster during the season.
		/// </summary>
		public ICollection<RosterCoach> Coaches { get; set; } = new List<RosterCoach>();

		/// <summary>
		/// The collection of roster players representing the players assigned
		/// to this roster during the season.
		/// </summary>
		public ICollection<RosterPlayer> Players { get; set; } = new List<RosterPlayer>();

		#endregion
	}
}