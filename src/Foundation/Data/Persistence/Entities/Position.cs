using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a league-specific position used to classify player roles.
	/// Positions may be hierarchical, allowing broad categories (e.g., "Linebacker")
	/// to contain more specific sub-positions (e.g., "Middle Linebacker").
	/// </summary>
	public class Position
	{
		#region Properties

		/// <summary>
		/// The unique identifier for the position.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The human-readable name of the position (e.g., "Quarterback", "Center Back").
		/// </summary>
		public string Name { get; set; } = null!;

		/// <summary>
		/// The short code used to represent the position (e.g., "QB", "MLB").
		/// </summary>
		public string Abbreviation { get; set; } = null!;

		/// <summary>
		/// Optional descriptive text providing additional context about the position.
		/// </summary>
		public string? Description { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the league this position belongs to.
		/// </summary>
		public Guid LeagueId { get; set; }

		/// <summary>
		/// The identifier of the parent position, if this is a sub-position.
		/// </summary>
		public Guid? ParentId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Navigation to the league associated with this position.
		/// </summary>
		public League League { get; set; } = null!;

		/// <summary>
		/// Navigation to the parent position in the hierarchy, if applicable.
		/// </summary>
		public Position? Parent { get; set; }

		/// <summary>
		/// Navigation to the collection of sub-positions nested under this position.
		/// </summary>
		public ICollection<Position> Children { get; set; } = new List<Position>();

		/// <summary>
		/// Navigation to the collection of roster entry assignments referencing this position.
		/// </summary>
		public ICollection<RosterPlayerPosition> RosterPlayerPositions { get; set; } = new List<RosterPlayerPosition>();

		#endregion
	}
}