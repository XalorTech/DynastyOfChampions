using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a structural unit within a league. The base model stores only
	/// stable identity and structural relationships. All time-variant attributes
	/// and historical hierarchy changes are stored in <see cref="LeagueUnitHistory"/>.
	/// </summary>
	public class LeagueUnit
	{
		#region Properties

		/// <summary>
		/// The unique identifier for the league unit.
		/// </summary>
		public Guid Id { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the league to which this unit belongs.
		/// </summary>
		public Guid LeagueId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// The league associated with this unit.
		/// </summary>
		public League League { get; set; } = null!;

		/// <summary>
		/// The collection of teams associated with this unit.
		/// </summary>
		public ICollection<Team> Teams { get; set; } = new List<Team>();

		/// <summary>
		/// Historical records describing time-variant attributes and hierarchy changes.
		/// </summary>
		public ICollection<LeagueUnitHistory> History { get; set; } = new List<LeagueUnitHistory>();

		#endregion
	}
}