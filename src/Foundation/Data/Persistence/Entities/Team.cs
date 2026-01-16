using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a team competing within a league. The base model stores only
	/// stable identity and structural relationships. All time-variant attributes
	/// such as name, abbreviation, or location are stored in <see cref="TeamHistory"/>.
	/// </summary>
	public class Team
	{
		#region Properties

		/// <summary>
		/// The unique identifier for the team.
		/// </summary>
		public Guid Id { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the league unit to which this team belongs.
		/// </summary>
		public Guid LeagueUnitId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// The league unit associated with this team.
		/// </summary>
		public LeagueUnit LeagueUnit { get; set; } = null!;

		/// <summary>
		/// The collection of rosters associated with this team across seasons.
		/// </summary>
		public ICollection<Roster> Rosters { get; set; } = new List<Roster>();

		/// <summary>
		/// Historical records describing time-variant attributes of this team.
		/// </summary>
		public ICollection<TeamHistory> History { get; set; } = new List<TeamHistory>();

		#endregion
	}
}